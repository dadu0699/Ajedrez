Imports System.IO.Directory

Class MainWindow
    Private matriz(0 To 7, 0 To 7) As Pieces

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Board()
    End Sub

    Private Sub Board()
        Dim fondo As New Image
        Dim imagenBrush As New ImageBrush
        fondo.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\Fondo.png"))
        imagenBrush.ImageSource = fondo.Source
        Content.Background = imagenBrush

        Dim brown As New Image
        Dim imagenBrown As New ImageBrush
        brown.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\Brown.png"))
        imagenBrown.ImageSource = brown.Source

        Dim beige As New Image
        Dim imagenBeige As New ImageBrush
        beige.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\Beige.png"))
        imagenBeige.ImageSource = beige.Source

        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                If (x Mod 2) Then
                    Dim brownSquare As New Rectangle
                    brownSquare.Fill = imagenBrown
                    If (y Mod 2) Then
                        Grid.SetRow(brownSquare, y)
                        Grid.SetColumn(brownSquare, x - 1)
                    Else
                        Grid.SetRow(brownSquare, y)
                        Grid.SetColumn(brownSquare, x)
                    End If
                    Tablero.Children.Add(brownSquare)
                Else
                    Dim beigeSquare As New Rectangle
                    beigeSquare.Fill = imagenBeige
                    If (y Mod 2) Then
                        Grid.SetRow(beigeSquare, y)
                        Grid.SetColumn(beigeSquare, x + 1)
                    Else
                        Grid.SetRow(beigeSquare, y)
                        Grid.SetColumn(beigeSquare, x)
                    End If
                    Tablero.Children.Add(beigeSquare)
                End If
            Next
        Next

        For ubicacion As Integer = 0 To 7 Step 7
            Dim blackCastle As New Pieces
            blackCastle.Fill = Colores.BlackCastle
            Grid.SetColumn(blackCastle, ubicacion)
            Grid.SetRow(blackCastle, 0)
            Tablero.Children.Add(blackCastle)
            matriz(ubicacion, 0) = blackCastle

            Dim whiteCastle As New Pieces
            whiteCastle.Fill = Colores.WhiteCastle
            Grid.SetColumn(whiteCastle, ubicacion)
            Grid.SetRow(whiteCastle, 7)
            Tablero.Children.Add(whiteCastle)
            matriz(ubicacion, 7) = whiteCastle
        Next

        For ubicacion As Integer = 1 To 7 Step 5
            Dim blackKnight As New Pieces
            blackKnight.Fill = Colores.BlackKnight
            Grid.SetColumn(blackKnight, ubicacion)
            Grid.SetRow(blackKnight, 0)
            Tablero.Children.Add(blackKnight)
            matriz(ubicacion, 0) = blackKnight

            Dim whiteKnight As New Pieces
            whiteKnight.Fill = Colores.WhiteKnight
            Grid.SetColumn(whiteKnight, ubicacion)
            Grid.SetRow(whiteKnight, 7)
            Tablero.Children.Add(whiteKnight)
            matriz(ubicacion, 7) = whiteKnight
        Next

        For ubicacion As Integer = 2 To 7 Step 3
            Dim blackBishop As New Pieces
            blackBishop.Fill = Colores.BlackBishop
            Grid.SetColumn(blackBishop, ubicacion)
            Grid.SetRow(blackBishop, 0)
            Tablero.Children.Add(blackBishop)
            matriz(ubicacion, 0) = blackBishop

            Dim whiteBishop As New Pieces
            whiteBishop.Fill = Colores.WhiteBishop
            Grid.SetColumn(whiteBishop, ubicacion)
            Grid.SetRow(whiteBishop, 7)
            Tablero.Children.Add(whiteBishop)
            matriz(ubicacion, 7) = whiteBishop
        Next

        For ubicacion As Integer = 3 To 3
            Dim blackQueen As New Pieces
            blackQueen.Fill = Colores.BlackQueen
            Grid.SetColumn(blackQueen, ubicacion)
            Grid.SetRow(blackQueen, 0)
            Tablero.Children.Add(blackQueen)
            matriz(ubicacion, 0) = blackQueen

            Dim whiteQueen As New Pieces
            whiteQueen.Fill = Colores.WhiteQueen
            Grid.SetColumn(whiteQueen, ubicacion)
            Grid.SetRow(whiteQueen, 7)
            Tablero.Children.Add(whiteQueen)
            matriz(ubicacion, 7) = whiteQueen
        Next

        For ubicacion As Integer = 4 To 4
            Dim blackKing As New Pieces
            blackKing.Fill = Colores.BlackKing
            Grid.SetColumn(blackKing, ubicacion)
            Grid.SetRow(blackKing, 0)
            Tablero.Children.Add(blackKing)
            matriz(ubicacion, 0) = blackKing

            Dim whiteKing As New Pieces
            whiteKing.Fill = Colores.WhiteKing
            Grid.SetColumn(whiteKing, ubicacion)
            Grid.SetRow(whiteKing, 7)
            Tablero.Children.Add(whiteKing)
            matriz(ubicacion, 7) = whiteKing
        Next

        For ubicacion As Integer = 0 To 7
            Dim blackPawn As New Pieces
            blackPawn.Fill = Colores.BlackPawn
            Grid.SetColumn(blackPawn, ubicacion)
            Grid.SetRow(blackPawn, 1)
            Tablero.Children.Add(blackPawn)
            matriz(ubicacion, 1) = blackPawn

            Dim whitePawn As New Pieces
            whitePawn.Fill = Colores.WhitePawn
            Grid.SetColumn(whitePawn, ubicacion)
            Grid.SetRow(whitePawn, 6)
            Tablero.Children.Add(whitePawn)
            matriz(ubicacion, 6) = whitePawn
        Next
    End Sub

    Private Sub Window_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        tagA.Width = (e.NewSize.Width \ 8)
        tagB.Width = (e.NewSize.Width \ 8)
        tagC.Width = (e.NewSize.Width \ 8)
        tagD.Width = (e.NewSize.Width \ 8)
        tagE.Width = (e.NewSize.Width \ 8)
        tagF.Width = (e.NewSize.Width \ 8)
        tagG.Width = (e.NewSize.Width \ 8)
        tagH.Width = (e.NewSize.Width \ 8)
    End Sub

    Dim mouseX As Double
    Dim mouseY As Double
    Dim newX As Integer
    Dim newY As Integer
    Dim alternador As Boolean = True
    Dim objeto As Pieces

    Dim castlingShortW As Integer = 0
    Dim castlingShortB As Integer = 0
    Dim castlingLongW As Integer = 0
    Dim castlingLongB As Integer = 0

    Private Sub Tablero_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If IsNothing(objeto) Then
            objeto = matriz(mouseX, mouseY)
            newX = mouseX
            newY = mouseY
        ElseIf Not IsNothing(objeto) Then
            'White
            If alternador = True Then
                Try
                    'WhitePawn
                    If objeto.Fill = Colores.WhitePawn Then
                        WhitePaw()
                        'WhiteCastle
                    ElseIf objeto.Fill = Colores.WhiteCastle Then
                        Castle()
                        'WhiteKnight
                    ElseIf objeto.Fill = Colores.WhiteKnight Then
                        Knight()
                        'WhiteBishop
                    ElseIf objeto.Fill = Colores.WhiteBishop Then
                        Bishop()
                        'WhiteQueen
                    ElseIf objeto.Fill = Colores.WhiteQueen Then
                        Queen()
                        'WhiteKing
                    ElseIf objeto.Fill = Colores.WhiteKing Then
                        King()
                    Else
                        objeto = Nothing
                    End If
                Catch ex As Exception
                End Try
                'Black
            ElseIf alternador = False Then
                Try
                    'BlackPawn
                    If objeto.Fill = Colores.BlackPawn Then
                        BlackPaw()
                        'BlackCastle
                    ElseIf objeto.Fill = Colores.BlackCastle Then
                        Castle()
                        'BlackKnight
                    ElseIf objeto.Fill = Colores.BlackKnight Then
                        Knight()
                        'BlackBishop
                    ElseIf objeto.Fill = Colores.BlackBishop Then
                        Bishop()
                        'BlackQueen
                    ElseIf objeto.Fill = Colores.BlackQueen Then
                        Queen()
                        'BlackKing
                    ElseIf objeto.Fill = Colores.BlackKing Then
                        King()
                    Else
                        objeto = Nothing
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
        'MsgBox("Mi posición parte de: " & mouseX & " hasta " & mouseY)
    End Sub

    Private Sub Move()
        Tablero.Children.Remove(matriz(newX, newY))
        matriz(newX, newY) = Nothing
        Grid.SetColumn(objeto, mouseX)
        Grid.SetRow(objeto, mouseY)
        Tablero.Children.Add(objeto)
        matriz(mouseX, mouseY) = objeto
        objeto = Nothing
        If alternador = True Then
            alternador = False
        ElseIf alternador = False Then
            alternador = True
        End If
    End Sub

    Private Sub CastlingMove(newX1 As Integer, newY1 As Integer, mouseX1 As Integer, mouseY1 As Integer)
        objeto = matriz(newX1, newY1)
        Tablero.Children.Remove(matriz(newX1, newY1))
        matriz(newX1, newY1) = Nothing
        Grid.SetColumn(objeto, mouseX1)
        Grid.SetRow(objeto, mouseY1)
        Tablero.Children.Add(objeto)
        matriz(mouseX1, mouseY1) = objeto
        objeto = Nothing
    End Sub

    Private Sub WhitePaw()
        If mouseX = newX Then
            If newY = 6 Then
                If (mouseY = newY - 1) And IsNothing(matriz(mouseX, mouseY)) Or (mouseY = newY - 2) And IsNothing(matriz(mouseX, mouseY)) And IsNothing(matriz(mouseX, mouseY + 1)) Then
                    Move()
                Else
                    objeto = Nothing
                End If
            Else
                If (mouseY = newY - 1) And IsNothing(matriz(mouseX, mouseY)) Then
                    Move()
                Else
                    objeto = Nothing
                End If
            End If
        ElseIf (mouseX = newX - 1) Or (mouseX = newX + 1) Then
            If (mouseY = newY - 1) Then
                If Not IsNothing(matriz(mouseX, mouseY)) Then
                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                        matriz(mouseX, mouseY) = Nothing
                        Move()
                    Else
                        objeto = Nothing
                    End If
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub BlackPaw()
        If mouseX = newX Then
            If newY = 1 Then
                If (mouseY = newY + 1) And IsNothing(matriz(mouseX, mouseY)) Or (mouseY = newY + 2) And IsNothing(matriz(mouseX, mouseY)) And IsNothing(matriz(mouseX, mouseY - 1)) Then
                    Move()
                Else
                    objeto = Nothing
                End If
            Else
                If (mouseY = newY + 1) And IsNothing(matriz(mouseX, mouseY)) Then
                    Move()
                Else
                    objeto = Nothing
                End If
            End If
        ElseIf (mouseX = newX - 1) Or (mouseX = newX + 1) Then
            If (mouseY = newY + 1) Then
                If Not IsNothing(matriz(mouseX, mouseY)) Then
                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                        matriz(mouseX, mouseY) = Nothing
                        Move()
                    Else
                        objeto = Nothing
                    End If
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub Castle()
        If mouseX = newX Then
            If mouseY <> newY Then
                If newY > mouseY Then
                    For posicion As Integer = (newY - 1) To mouseY Step -1
                        If Not IsNothing(matriz(mouseX, posicion)) Then
                            If posicion = mouseY Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 7 Then
                                            castlingLongW = castlingLongW + 1
                                        ElseIf newX = 7 And newY = 7 Then
                                            castlingShortW = castlingShortW + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 0 Then
                                            castlingLongB = castlingLongB + 1
                                        ElseIf newX = 7 And newY = 0 Then
                                            castlingShortB = castlingShortB + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseY Then
                            If IsNothing(matriz(mouseX, posicion)) Then
                                If alternador = True Then
                                    If newX = 0 And newY = 7 Then
                                        castlingLongW = castlingLongW + 1
                                    ElseIf newX = 7 And newY = 7 Then
                                        castlingShortW = castlingShortW + 1
                                    End If
                                ElseIf alternador = False Then
                                    If newX = 0 And newY = 0 Then
                                        castlingLongB = castlingLongB + 1
                                    ElseIf newX = 7 And newY = 0 Then
                                        castlingShortB = castlingShortB + 1
                                    End If
                                End If
                                Move()
                            End If
                        End If
                    Next
                ElseIf newY < mouseY Then
                    For posicion As Integer = (newY + 1) To mouseY Step 1
                        If Not IsNothing(matriz(mouseX, posicion)) Then
                            If posicion = mouseY Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 7 Then
                                            castlingLongW = castlingLongW + 1
                                        ElseIf newX = 7 And newY = 7 Then
                                            castlingShortW = castlingShortW + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 0 Then
                                            castlingLongB = castlingLongB + 1
                                        ElseIf newX = 7 And newY = 0 Then
                                            castlingShortB = castlingShortB + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseY Then
                            If IsNothing(matriz(mouseX, posicion)) Then
                                If alternador = True Then
                                    If newX = 0 And newY = 7 Then
                                        castlingLongW = castlingLongW + 1
                                    ElseIf newX = 7 And newY = 7 Then
                                        castlingShortW = castlingShortW + 1
                                    End If
                                ElseIf alternador = False Then
                                    If newX = 0 And newY = 0 Then
                                        castlingLongB = castlingLongB + 1
                                    ElseIf newX = 7 And newY = 0 Then
                                        castlingShortB = castlingShortB + 1
                                    End If
                                End If
                                Move()
                            End If
                        End If
                    Next
                End If
            End If
        ElseIf mouseY = newY Then
            If mouseX <> newX Then
                If newX > mouseX Then
                    For posicion As Integer = (newX - 1) To mouseX Step -1
                        If Not IsNothing(matriz(posicion, newY)) Then
                            If posicion = mouseX Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 7 Then
                                            castlingLongW = castlingLongW + 1
                                        ElseIf newX = 7 And newY = 7 Then
                                            castlingShortW = castlingShortW + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 0 Then
                                            castlingLongB = castlingLongB + 1
                                        ElseIf newX = 7 And newY = 0 Then
                                            castlingShortB = castlingShortB + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseX Then
                            If IsNothing(matriz(posicion, mouseY)) Then
                                If alternador = True Then
                                    If newX = 0 And newY = 7 Then
                                        castlingLongW = castlingLongW + 1
                                    ElseIf newX = 7 And newY = 7 Then
                                        castlingShortW = castlingShortW + 1
                                    End If
                                ElseIf alternador = False Then
                                    If newX = 0 And newY = 0 Then
                                        castlingLongB = castlingLongB + 1
                                    ElseIf newX = 7 And newY = 0 Then
                                        castlingShortB = castlingShortB + 1
                                    End If
                                End If
                                Move()
                            End If
                        End If
                    Next
                ElseIf newX < mouseX Then
                    For posicion As Integer = (newX + 1) To mouseX Step 1
                        If Not IsNothing(matriz(posicion, mouseY)) Then
                            If posicion = mouseX Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 7 Then
                                            castlingLongW = castlingLongW + 1
                                        ElseIf newX = 7 And newY = 7 Then
                                            castlingShortW = castlingShortW + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        If newX = 0 And newY = 0 Then
                                            castlingLongB = castlingLongB + 1
                                        ElseIf newX = 7 And newY = 0 Then
                                            castlingShortB = castlingShortB + 1
                                        End If
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseX Then
                            If IsNothing(matriz(posicion, mouseY)) Then
                                If alternador = True Then
                                    If newX = 0 And newY = 7 Then
                                        castlingLongW = castlingLongW + 1
                                    ElseIf newX = 7 And newY = 7 Then
                                        castlingShortW = castlingShortW + 1
                                    End If
                                ElseIf alternador = False Then
                                    If newX = 0 And newY = 0 Then
                                        castlingLongB = castlingLongB + 1
                                    ElseIf newX = 7 And newY = 0 Then
                                        castlingShortB = castlingShortB + 1
                                    End If
                                End If
                                Move()
                            End If
                        End If
                    Next
                End If
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub Knight()
        If (mouseX = newX - 1) Or (mouseX = newX + 1) Then
            If (mouseY = newY - 2) Or (mouseY = newY + 2) Then
                If IsNothing(matriz(mouseX, mouseY)) Then
                    Move()
                ElseIf Not IsNothing(matriz(mouseX, mouseY)) Then
                    If alternador = True Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    ElseIf alternador = False Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    End If
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        ElseIf (mouseX = newX - 2) Or (mouseX = newX + 2) Then
            If (mouseY = newY - 1) Or (mouseY = newY + 1) Then
                If IsNothing(matriz(mouseX, mouseY)) Then
                    Move()
                ElseIf Not IsNothing(matriz(mouseX, mouseY)) Then
                    If alternador = True Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    ElseIf alternador = False Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    End If
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub Bishop()
        Dim salirFor As Boolean = True
        If mouseX > newX Then
            If newY > mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY - 1) To mouseY Step -1
                        For posicion1 As Integer = (newX + 1) To mouseX Step 1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            ElseIf newY < mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY + 1) To mouseY Step 1
                        For posicion1 As Integer = (newX + 1) To mouseX Step 1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        ElseIf mouseX < newX Then
            If newY > mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY - 1) To mouseY Step -1
                        For posicion1 As Integer = (newX - 1) To mouseX Step -1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            ElseIf newY < mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY + 1) To mouseY Step 1
                        For posicion1 As Integer = (newX - 1) To mouseX Step -1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub Queen()
        Dim salirFor As Boolean = True
        If mouseX = newX Then
            If mouseY <> newY Then
                If newY > mouseY Then
                    For posicion As Integer = (newY - 1) To mouseY Step -1
                        If Not IsNothing(matriz(mouseX, posicion)) Then
                            If posicion = mouseY Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseY Then
                            If IsNothing(matriz(mouseX, posicion)) Then
                                Move()
                            End If
                        End If
                    Next
                ElseIf newY < mouseY Then
                    For posicion As Integer = (newY + 1) To mouseY Step 1
                        If Not IsNothing(matriz(mouseX, posicion)) Then
                            If posicion = mouseY Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseY Then
                            If IsNothing(matriz(mouseX, posicion)) Then
                                Move()
                            End If
                        End If
                    Next
                End If
            End If
        ElseIf mouseY = newY Then
            If mouseX <> newX Then
                If newX > mouseX Then
                    For posicion As Integer = (newX - 1) To mouseX Step -1
                        If Not IsNothing(matriz(posicion, newY)) Then
                            If posicion = mouseX Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseX Then
                            If IsNothing(matriz(posicion, mouseY)) Then
                                Move()
                            End If
                        End If
                    Next
                ElseIf newX < mouseX Then
                    For posicion As Integer = (newX + 1) To mouseX Step 1
                        If Not IsNothing(matriz(posicion, mouseY)) Then
                            If posicion = mouseX Then
                                If alternador = True Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                ElseIf alternador = False Then
                                    If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                        Tablero.Children.Remove(matriz(mouseX, mouseY))
                                        matriz(mouseX, mouseY) = Nothing
                                        Move()
                                    Else
                                        objeto = Nothing
                                    End If
                                End If
                            Else
                                objeto = Nothing
                                Exit For
                            End If
                        ElseIf posicion = mouseX Then
                            If IsNothing(matriz(posicion, mouseY)) Then
                                Move()
                            End If
                        End If
                    Next
                End If
            End If
        ElseIf mouseX > newX Then
            If newY > mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY - 1) To mouseY Step -1
                        For posicion1 As Integer = (newX + 1) To mouseX Step 1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            ElseIf newY < mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY + 1) To mouseY Step 1
                        For posicion1 As Integer = (newX + 1) To mouseX Step 1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        ElseIf mouseX < newX Then
            If newY > mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY - 1) To mouseY Step -1
                        For posicion1 As Integer = (newX - 1) To mouseX Step -1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            ElseIf newY < mouseY Then
                If Math.Abs(newX - mouseX) = Math.Abs(newY - mouseY) Then
                    For posicion As Integer = (newY + 1) To mouseY Step 1
                        For posicion1 As Integer = (newX - 1) To mouseX Step -1
                            If Math.Abs(newX - posicion1) = Math.Abs(newY - posicion) Then
                                If Not IsNothing(matriz(posicion1, posicion)) Then
                                    If posicion1 = mouseX And posicion = mouseY Then
                                        If alternador = True Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        ElseIf alternador = False Then
                                            If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                                                Tablero.Children.Remove(matriz(mouseX, mouseY))
                                                matriz(mouseX, mouseY) = Nothing
                                                Move()
                                            Else
                                                objeto = Nothing
                                            End If
                                        End If
                                    Else
                                        objeto = Nothing
                                        salirFor = False
                                        Exit For
                                    End If
                                ElseIf posicion1 = mouseX And posicion = mouseY Then
                                    If IsNothing(matriz(mouseX, mouseY)) Then
                                        Move()
                                    End If
                                End If
                            End If
                        Next
                        If salirFor = False Then
                            Exit For
                        End If
                    Next
                Else
                    objeto = Nothing
                End If
            Else
                objeto = Nothing
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub King()
        If newX = mouseX Then
            If (mouseY = newY + 1) Or (mouseY = newY - 1) Then
                If Not IsNothing(matriz(mouseX, mouseY)) Then
                    If alternador = True Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            castlingShortW = castlingShortW + 1
                            castlingLongW = castlingLongW + 1
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    ElseIf alternador = False Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            castlingShortB = castlingShortB + 1
                            castlingLongB = castlingLongB + 1
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    End If
                Else
                    If alternador = True Then
                        castlingShortW = castlingShortW + 1
                        castlingLongW = castlingLongW + 1
                    ElseIf alternador = False Then
                        castlingShortB = castlingShortB + 1
                        castlingLongB = castlingLongB + 1
                    End If
                    Move()
                End If
            Else
                objeto = Nothing
            End If
        ElseIf newY = mouseY Then
            If (mouseX = newX + 1) Or (mouseX = newX - 1) Then
                If Not IsNothing(matriz(mouseX, mouseY)) Then
                    If alternador = True Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            castlingShortW = castlingShortW + 1
                            castlingLongW = castlingLongW + 1
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    ElseIf alternador = False Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            castlingShortB = castlingShortB + 1
                            castlingLongB = castlingLongB + 1
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    End If
                Else
                    If alternador = True Then
                        castlingShortW = castlingShortW + 1
                        castlingLongW = castlingLongW + 1
                    ElseIf alternador = False Then
                        castlingShortB = castlingShortB + 1
                        castlingLongB = castlingLongB + 1
                    End If
                    Move()
                End If
            ElseIf (mouseX = newX + 2) Then
                If alternador = True Then
                    If (mouseY = 7) Then
                        If IsNothing(matriz(newX + 2, mouseY)) And IsNothing(matriz(newX + 1, mouseY)) And castlingShortW = 0 Then
                            castlingShortW = castlingShortW + 1
                            castlingLongW = castlingLongW + 1
                            Move()
                            CastlingMove(7, 7, 5, 7)
                        Else
                            objeto = Nothing
                        End If
                    Else
                        objeto = Nothing
                    End If
                ElseIf alternador = False Then
                    If (mouseY = 0) Then
                        If IsNothing(matriz(newX + 2, mouseY)) And IsNothing(matriz(newX + 1, mouseY)) And castlingShortB = 0 Then
                            castlingShortB = castlingShortB + 1
                            castlingLongB = castlingLongB + 1
                            Move()
                            CastlingMove(7, 0, 5, 0)
                        Else
                            objeto = Nothing
                        End If
                    Else
                        objeto = Nothing
                    End If
                End If
            ElseIf (mouseX = newX - 2) Then
                If alternador = True Then
                    If (mouseY = 7) Then
                        If IsNothing(matriz(newX - 2, mouseY)) And IsNothing(matriz(newX - 1, mouseY)) And castlingLongW = 0 Then
                            castlingShortW = castlingShortW + 1
                            castlingLongW = castlingLongW + 1
                            Move()
                            CastlingMove(0, 7, 3, 7)
                        Else
                            objeto = Nothing
                        End If
                    Else
                        objeto = Nothing
                    End If
                ElseIf alternador = False Then
                    If (mouseY = 0) Then
                        If IsNothing(matriz(newX - 2, mouseY)) And IsNothing(matriz(newX - 1, mouseY)) And castlingLongB = 0 Then
                            castlingShortB = castlingShortB + 1
                            castlingLongB = castlingLongB + 1
                            Move()
                            CastlingMove(0, 0, 3, 0)
                        Else
                            objeto = Nothing
                        End If
                    Else
                        objeto = Nothing
                    End If
                End If
            Else
                objeto = Nothing
            End If
        ElseIf (mouseX = newX + 1) Or (mouseX = newX - 1) Then
            If (mouseY = newY + 1) Or (mouseY = newY - 1) Then
                If Not IsNothing(matriz(mouseX, mouseY)) Then
                    If alternador = True Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("Black") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            castlingShortW = castlingShortW + 1
                            castlingLongW = castlingLongW + 1
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    ElseIf alternador = False Then
                        If matriz(mouseX, mouseY).Fill.ToString.Contains("White") Then
                            Tablero.Children.Remove(matriz(mouseX, mouseY))
                            matriz(mouseX, mouseY) = Nothing
                            castlingShortB = castlingShortB + 1
                            castlingLongB = castlingLongB + 1
                            Move()
                        Else
                            objeto = Nothing
                        End If
                    End If
                Else
                    If alternador = True Then
                        castlingShortW = castlingShortW + 1
                        castlingLongW = castlingLongW + 1
                    ElseIf alternador = False Then
                        castlingShortB = castlingShortB + 1
                        castlingLongB = castlingLongB + 1
                    End If
                    Move()
                End If
            Else
                objeto = Nothing
            End If
        Else
            objeto = Nothing
        End If
    End Sub

    Private Sub Tablero_MouseMove(sender As Object, e As MouseEventArgs)
        Dim letra As String
        Dim numero As Double
        Dim turno As String

        mouseX = e.GetPosition(sender).X \ 92.5
        mouseY = e.GetPosition(sender).Y \ 78.125

        numero = e.GetPosition(sender).Y \ -78.125 + 8

        Select Case mouseX
            Case 0
                letra = "a"
            Case 1
                letra = "b"
            Case 2
                letra = "c"
            Case 3
                letra = "d"
            Case 4
                letra = "e"
            Case 5
                letra = "f"
            Case 6
                letra = "g"
            Case 7
                letra = "h"
        End Select

        Select Case alternador
            Case True
                turno = "Blancas"
            Case False
                turno = "Negras"
        End Select

        Informacion.Text = "Posición: " & letra & numero & "   Turno: " & turno & "   Tiempo: 14:53:00"
    End Sub

    Private Sub ShutDown(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub Reboot(sender As Object, e As RoutedEventArgs)
        Tablero.Children.Clear()
        For y As Integer = 0 To 7 Step 1
            For x As Integer = 0 To 7 Step 1
                matriz(x, y) = Nothing
            Next
        Next
        alternador = True
        castlingShortW = 0
        castlingShortB = 0
        castlingLongW = 0
        castlingLongB = 0
        Board()
    End Sub

    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = (Key.F5) Then
            Tablero.Children.Clear()
            For y As Integer = 0 To 7 Step 1
                For x As Integer = 0 To 7 Step 1
                    matriz(x, y) = Nothing
                Next
            Next
            alternador = True
            castlingShortW = 0
            castlingShortB = 0
            castlingLongW = 0
            castlingLongB = 0
            Board()
        ElseIf e.Key = (Key.LeftAlt + Key.F4) Then
            Close()
        End If
    End Sub
End Class
