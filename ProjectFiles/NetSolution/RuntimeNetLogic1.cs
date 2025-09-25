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

public class RuntimeNetLogic1 : BaseNetLogic
{
    private IUAVariable cambiamento;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("Progetto avviato");
        cambiamento = Project.Current.GetVariable("Model/VarCambiamento");
        cambiamento.VariableChange += Cambiamento_VariableChange;
    }

    private void Cambiamento_VariableChange(object sender, VariableChangeEventArgs e)
    {
        var Azione = Project.Current.GetVariable("Model/VarAzione");
        Azione.Value += 1;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("Progetto arrestato");
        cambiamento.VariableChange -= Cambiamento_VariableChange;
    }

    [ExportMethod]
    public void mioLog(string testoMessaggio)
    {
        Log.Info(testoMessaggio);
    }
}
