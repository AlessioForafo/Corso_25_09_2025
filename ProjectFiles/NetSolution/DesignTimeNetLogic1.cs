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
using FTOptix.Modbus;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void MioMetodoDT()
    {
        // Insert code to be executed by the method
        var testoMessaggio = LogicObject.GetVariable("TestoMessaggio");
        Log.Info(testoMessaggio.Value);
    }

    [ExportMethod]
    public void CreaAllarmi()
    {
        // Insert code to be executed by the method
        for (uint i = 0; i < 10; i++)
        {
            var arrayPLC = Project.Current.GetVariable("Model/Allarmi");
            var mioAllarme = InformationModel.Make<DigitalAlarm>("Allarme_" + i);
            mioAllarme.Message = "Testo allarme " + i;
            mioAllarme.AutoAcknowledge = true;
            mioAllarme.InputValueVariable.SetDynamicLink(arrayPLC,i,DynamicLinkMode.Read);

            if (Project.Current.Get<DigitalAlarm>("Alarms/Allarme_" + i) == null)
            {
                Project.Current.Get("Alarms").Add(mioAllarme);
            }
        }

    }


    [ExportMethod]
    public void CancellaAllarmi()
    {
        foreach (var item in Project.Current.Get("Alarms").Children)
        {
            item.Delete();
        }
    }

}
