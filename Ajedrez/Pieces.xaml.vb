Imports System.IO.Directory

Public Class Pieces
    Private imagen As New Image
    Private imagenBrush As New ImageBrush
    Private color As Colores

    Public Property Fill As Colores
        Get
            Return Me.color
        End Get
        Set(value As Colores)
            Me.color = value
            UpdateColor(value)
        End Set
    End Property

    Private Sub UpdateColor(ByVal color As Colores)
        Select Case color
            Case Colores.BlackBishop
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\BlackBishop.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.BlackCastle
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\BlackCastle.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.BlackKing
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\BlackKing.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.BlackKnight
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\BlackKnight.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.BlackPawn
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\BlackPawn.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.BlackQueen
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\BlackQueen.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush

            Case Colores.WhiteBishop
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\WhiteBishop.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.WhiteCastle
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\WhiteCastle.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.WhiteKing
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\WhiteKing.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.WhiteKnight
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\WhiteKnight.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.WhitePawn
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\WhitePawn.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
            Case Colores.WhiteQueen
                imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Resources\WhiteQueen.png"))
                imagenBrush.ImageSource = imagen.Source
                Content.Background = imagenBrush
        End Select
    End Sub
End Class
