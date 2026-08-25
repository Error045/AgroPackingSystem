Public Class SesionPesaje
    ' --- CONFIGURACIÓN DEL LOTE ---
    Public Property LimiteBines As Integer = 1
    Public Property DiccionarioCabecera As New Dictionary(Of String, String)

    ' --- ESTADO GLOBAL ---
    Public Property PesoAcumuladoAnterior As Double = 0.0

    ' --- RESULTADOS (Lo que antes sacabas de los controles visuales) ---
    Public Property PesajesCompletados As New List(Of PesajeFinal)

    ' Propiedad para saber si ya terminamos
    Public ReadOnly Property CicloCompleto As Boolean
        Get
            Return PesajesCompletados.Count >= LimiteBines
        End Get
    End Property

    ' Método para registrar un peso individual
    Public Sub RegistrarPesaje(pesoBrutoBalanza As Double, taraSeleccionada As Double, idContenedor As Integer)
        ' 1. Calculamos el bruto real de ESTE bin restando lo que pesaba la balanza antes
        Dim brutoIndividual As Double = pesoBrutoBalanza - PesoAcumuladoAnterior
        Dim netoIndividual As Double = brutoIndividual - taraSeleccionada

        ' 2. Creamos el objeto final (Igual que como lo hacías antes en MostrarResumen)
        Dim p As New PesajeFinal()
        p.Titulo = "📦 CONTENEDOR #" & (PesajesCompletados.Count + 1)
        p.IdContenedor = idContenedor
        p.Tara = taraSeleccionada
        p.PesoBruto = brutoIndividual
        p.PesoNeto = netoIndividual

        ' 3. Lo guardamos en la lista de memoria
        PesajesCompletados.Add(p)

        ' 4. Actualizamos el acumulado para el SIGUIENTE bin
        PesoAcumuladoAnterior = pesoBrutoBalanza
    End Sub

    Public Sub IniciarNuevaSesion(cantidad As Integer, cabecera As Dictionary(Of String, String))
        LimiteBines = cantidad
        DiccionarioCabecera = cabecera
        PesoAcumuladoAnterior = 0.0
        PesajesCompletados.Clear()
    End Sub
End Class