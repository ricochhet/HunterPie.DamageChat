import json
import os
import pathlib
import hashlib

# Put the files you want to move to the binaries directory here
filesToMove = [
    "DamageChat.dll",
    "module.json",
    "config.json"
]

relativePath = "plugin"

for f in os.listdir(relativePath):
    if (f.replace(relativePath, "") in filesToMove):
        os.rename(f"{relativePath}\\{f}", f"binaries\\{f.replace(relativePath, '')}")