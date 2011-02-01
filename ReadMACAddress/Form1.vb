Imports System.Management


Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadMac.Click
        txtDisplay.Text = GetMacAddress()
    End Sub
    Public Function GetMacAddress() As String
        '
        ' Requires setting a reference to System.Management.dll
        '
        Try
            Dim strMACAddress As String = ""
            '
            ' Create the query, in SQL syntax, to retrieve the properties from
            ' the active Network Adapter.
            '
            Dim strQuery As String = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"
            '
            ' Create a ManagementObjectSearcher object passing in the query to run.

            Dim query As ManagementObjectSearcher = New ManagementObjectSearcher(strQuery)

            '
            ' Create a ManagementObjectCollection assigning it the results of the query.
            '
            Dim queryCollection As ManagementObjectCollection = query.Get()

            '
            ' Loop through the results extracting the MAC Address.
            '
            Dim MO As ManagementObject

            For Each mo In queryCollection

                strMACAddress = MO("MacAddress").ToString()

                Exit For
            Next

            Return strMACAddress

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
