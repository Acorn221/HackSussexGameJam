# -*- coding: utf-8 -*-
import sys
import asyncio
import platform
import signal
import pyautogui

from bleak import BleakClient, BleakScanner
from bleak.exc import BleakError

import numpy as np 


END = False
def sigint_handler(signum, frame):
    global END
    END = True
    print ('Interrupted!')
signal.signal(signal.SIGINT, sigint_handler)


ble_address = (
    "D3:99:D4:9C:54:C3"
)

receive_UUID = "0000aadc-0000-1000-8000-00805f9b34fb"

key = [176,  81, 104, 224,  86, 137,
       237, 119,  38,  26, 193, 161,
       210, 126, 150,  81,  93,  13,
       236, 249,  89, 235,  88,  24,
       113,  81, 214, 131, 130, 199,
         2, 169,  39, 165, 171, 41]

pre_value = -1
value = -1


def toHexVal(value, key):
    raw = list(value)
    k1 = raw[-1] >> 4 & 0xf
    k2 = raw[-1] & 0xf
    for i in range(18):
        raw[i] += key[i + k1] + key[i + k2]
    raw = raw[:18]

    valhex = []
    for i in range(len(raw)):
        valhex.append(raw[i] >> 4 & 0xf)
        valhex.append(raw[i]  & 0xf)
    return valhex


def notification_handler(sender, data):
    global value
    value = data


async def main(address, char_uuid):
    global value, pre_value, key, END
    device = await BleakScanner.find_device_by_address(address, timeout=30.0)
    if not device:
        raise BleakError(f"Could not find {ble_address}")
    
    async with BleakClient(device) as client:
        print(f"Connected: {client.is_connected}")
        await client.start_notify(char_uuid, notification_handler)
        while True:
            if value != pre_value:
                pre_value = value
                valhex = toHexVal(value, key)
                print(valhex)
                anticlockwise = True if valhex[-3] == 3 else False
                if valhex[-4] == 1:
                    pyautogui.typewrite(' ')

                if valhex[-4] == 6:
                    if anticlockwise:
                        pyautogui.typewrite('[')
                    else:
                        pyautogui.typewrite(']')

            else:
                await asyncio.sleep(0.1)

            if END == True:
                break
        await client.stop_notify(char_uuid)


if __name__ == "__main__":
    asyncio.run(main(ble_address,receive_UUID))
    