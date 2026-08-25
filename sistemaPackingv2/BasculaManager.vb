Public Class BasculaManager
    ' --- PATRÓN SINGLETON (Una sola instancia para todo el programa) ---
    Private Shared _instancia As BasculaManager
    Public Shared ReadOnly Property Instancia As BasculaManager
        Get
            If _instancia Is Nothing Then _instancia = New BasculaManager()
            Return _instancia
        End Get
    End Property

    ' Esta es la variable que todos los controles leerán
    Public Property PesoActual As Double = 0.0

    ' Constructor privado para que nadie más pueda crear instancias
    Private Sub New()
    End Sub

    ' Método para actualizar el peso desde el puerto serial (llámalo desde tu evento DataReceived)
    Public Sub ActualizarPeso(nuevoPeso As Double)
        PesoActual = nuevoPeso
    End Sub
End Class