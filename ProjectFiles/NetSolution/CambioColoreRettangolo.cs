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

public class CambioColoreRettangolo : BaseNetLogic
{
    private IUAVariable cambioColore;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        cambioColore = LogicObject.GetVariable("Variable1");
        cambioColore.VariableChange += CambioColore_VariableChange;
        Cambio_Colore(cambioColore.Value);
    }

    private void CambioColore_VariableChange(object sender, VariableChangeEventArgs e)
    {
        Cambio_Colore(e.NewValue);
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        cambioColore.VariableChange -= CambioColore_VariableChange;
    }

    public void Cambio_Colore(bool condizione)
    {
        var rettangolo = (Rectangle)Owner;
        if (condizione == true)
        {
            rettangolo.FillColor = Colors.Red;
        }
        else
        {
            rettangolo.FillColor = Colors.Blue;
        }
    }
}
