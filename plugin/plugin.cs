using System;
using System.IO;
using HunterPie;
using System.Linq;
using HunterPie.Core;
using Newtonsoft.Json;
using HunterPie.Core.Input;
using HunterPie.Core.Native;
using System.Threading.Tasks;
using System.Collections.Generic;
using Debugger = HunterPie.Logger.Debugger;

namespace HunterPie.Plugins
{
  public class DamageChat : IPlugin
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Game Context { get; set; }

    private int hotKeyId;
    public class DamageInformation
    {
      public float DamageValue { get; set; }
      public string DamageMessage { get; set; }
    }

    public static string configSerialized = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Modules\\DamageChat", "config.json"));
    ModConfig config = JsonConvert.DeserializeObject<ModConfig>(configSerialized);

    public void Initialize(Game context)
    {
      Name = "DamageChat";
      Description = "Post damage dealt to chat.";

      Context = context;

      SetHotkeys();
    }

    public void SetHotkeys() 
    {
      int hkId = Hotkey.Register(config.Hotkey, HotkeyCallback);
      if (hkId > 0) 
      {
        hotKeyId = hkId;
        this.Log("Hotkey registered successfully!");
      } 
      else 
      {
        this.Log("Hotkey failed to register.");
      }
    }

    public async void HotkeyCallback() 
    {
      List<Member> members = Context.Player.PlayerParty.Members;
      List<DamageInformation> damageInformation = new List<DamageInformation>();

      foreach (Member member in members)
      {
        if (member.Name != "" && member.Name != null)
        {
          string DamageString = $"{member.Name}: {member.Damage} ({(Math.Floor(member.DamagePercentage * 100) / 100) * 100}%) damage";
          damageInformation.Add(new DamageInformation { DamageValue = member.Damage, DamageMessage = DamageString });
        }
      }

      List<DamageInformation> sortedDamageInformation = damageInformation.OrderBy(i => i.DamageValue).ToList();
      sortedDamageInformation.Reverse();

      foreach (DamageInformation information in sortedDamageInformation)
      {
        await Chat.Say(information.DamageMessage);
        await Task.Delay(config.MessageDelay);
      }
    }

    public void Unload()
    {
      Hotkey.Unregister(hotKeyId);
    }

    internal class ModConfig
    {
      public string Hotkey { get; set; } = "F5";
      public Int32 MessageDelay { get; set; } = 10;
    }
  }
}