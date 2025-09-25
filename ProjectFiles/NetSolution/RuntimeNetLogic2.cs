#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.Modbus;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
#endregion

public class RuntimeNetLogic2 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        foreach (IUAVariable item in Project.Current.Get("Model/Folder1").Children)
        {
            var oggetto = InformationModel.Make<SpinBox>(item.BrowseName);
            oggetto.HorizontalAlignment = HorizontalAlignment.Center;
            oggetto.ValueVariable.SetDynamicLink(item, DynamicLinkMode.ReadWrite);
            Owner.Add(oggetto);
        }
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped

        
    }
}
