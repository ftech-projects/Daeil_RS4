Public Class Form1

    Private Sub Switch1_StateChanged(ByVal sender As System.Object, ByVal e As NationalInstruments.UI.ActionEventArgs) Handles Switch1.StateChanged
        Try
            If Switch1.Value Then
                DaqTaskComponent1.StartRead()
            Else
                DaqTaskComponent1.StopRead()
            End If
        Catch ex As NationalInstruments.DAQmx.DaqException
            MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Switch1.Value = False
        End Try
    End Sub

    Private Sub DaqTaskComponent1_DataReady(ByVal sender As System.Object, ByVal e As DaqApplication1.DaqTaskComponentDataReadyEventArgs) Handles DaqTaskComponent1.DataReady
        System.Threading.Monitor.Enter(DaqTaskComponent1)
        Dim acquiredData() As NationalInstruments.AnalogWaveform(Of Double) = e.GetData
        WaveformGraph1.PlotWaveforms(acquiredData)
        System.Threading.Monitor.Exit(DaqTaskComponent1)
    End Sub

    Private Sub DaqTaskComponent1_Error(ByVal sender As System.Object, ByVal e As NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs) Handles DaqTaskComponent1.Error
        'TODO: Handle DAQ errors.
        Dim message As String = e.Exception.Message
        MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Switch1.Value = False
    End Sub
End Class
