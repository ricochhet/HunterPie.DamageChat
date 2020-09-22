# HunterPie - Damage Chat

This plugin sends the damage dealt of each member to chat.

## Installation

**MINIMUM HUNTERPIE VERSION v1.0.3.97**

1. Download the `module.json`.
2. Place it's contents to `HunterPie/Modules/DamageChat`.
3. Run HunterPie.
4. HunterPie will automatically download additional files. 
> **NOTE:** You can edit the `HunterPie/Modules/DamageChat/config.json` to change the hotkey used.

## Usage

1. In a quest press **CTRL + SHIFT + F5** to send damage to chat.
> **NOTE:** This will not work in offline mode, in the Kulve Taroth siege, Zorah Magdaros quests, or in Guiding Lands / Expeditions.

## For more custom commands

HunterPie plugins have access to every information HunterPie tracks, see the [Plugin documentation here](https://docs.hunterpie.me/?p=Plugins/plugins.md), if you want to add more commands, you can find the source code for this plugin [here](https://github.com/ricochhet/HunterPie.Plugins/blob/master/DamageChat/main.cs).

> **NOTE:** Don't forget to rename the `main.cs` to anything else after you've compiled it, otherwise HunterPie will compile it over and over every time you start it again.