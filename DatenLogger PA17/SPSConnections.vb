

Partial Public Class SPSConnections
    Partial Public Class SPS_ParameterDataTable
        Private Sub SPS_ParameterDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.SPS_idColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class
End Class

