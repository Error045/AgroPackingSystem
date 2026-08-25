Imports System

' =====================================================================
' ARCHIVO: Entidades.vb
' PROPÓSITO: Clases mensajeras y de estructura de datos.
' REGLA DE ORO: ¡Cero lógica de interfaz, cero Timers, cero Base de Datos!
' =====================================================================

' Esta clase empaqueta los datos que el pesaje le entregará a quien lo escuche
Public Class EventoPesajeArgs
    Inherits EventArgs

    Public Property PesoNeto As Double
    Public Property IdContenedor As Integer
    Public Property FechaHora As DateTime

End Class

' Esta clase guarda la información del botón seleccionado
Public Class ContenedorInfo

    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Tara As Double
    Public Property Capacidad As Double

End Class

' Representa un pesaje ya validado y listo para ser guardado
Public Class PesajeFinal
    Public Property Titulo As String        ' Ej: "Pesaje 1"
    Public Property IdContenedor As Integer
    Public Property Tara As Double
    Public Property PesoBruto As Double
    Public Property PesoNeto As Double
End Class