using ResoniteModLoader;
using FrooxEngine;
using Elements.Core;

namespace CreateWorldConfig
{
    public class CreateWorldConfig : ResoniteMod
    {
        public override string Name => "CreateWorldConfig";
        public override string Author => "art0007i";
        public override string Version => "2.0.0";
        public override string Link => "https://github.com/art0007i/CreateWorldConfig/";
        public override void OnEngineInit()
        {
            // no harmony required :)
            //Harmony harmony = new Harmony("me.art0007i.CreateWorldConfig");

            Engine.Current.RunPostInit(() =>
            {
                DevCreateNewForm.AddAction("Editor", "World Configuration", delegate (Slot s)
                {
                    WorkerInspector.Create(s, s.World.Configuration);
                }); 
                DevCreateNewForm.AddAction("Editor", "World Permission Controller", delegate (Slot s)
                {
                    WorkerInspector.Create(s, s.World.Permissions);
                });
            });
        }
    }
}