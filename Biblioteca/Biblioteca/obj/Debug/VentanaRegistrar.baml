   M S B A M L   `   `   `  ����E  ABiblioteca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Biblioteca
Biblioteca  5   	   !    Biblioteca.VentanaRegistrar   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Biblioteca     5   	     � Title$  VentanaRegistrar��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ btn_buscarLibro��5
      $
��Left=�6+   $��
388,30,0,0q�6F   $	��Top=�6Z   $��37��6r   $��22��6}   .��5      �� -   5         ��Name$ ImageBuscar��5      $��imagenes/Search.png��6)   5      �� 5   
   -   5         ��Name$ cbCampos��5      $
��Left=�6%   $��	21,30,0,0q�6@   $	��Top=�6S   $	��120��6k   �� 5   
   -   5         ��Name$ 
tbBusqueda��5      $
��Left=�6&   $��22��6A   $��
147,30,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��225��6�   �� 5   
   -   5         ��Name$ label��5      $��Buscar Por:��6   $
��Left=�65   $��27��6P   $��21,3,0,0q�6\   $	��Top=�6n   $	��126��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgEjemplares��5         AutoGenerateColumns .  $
��Left=�6F   $	��201��6a   $��
394,85,0,0q�6n   $	��Top=�6�   $	��355��6�   	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo Libro��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *codigo+  5      $ Num Ejemplar��6%    6;   �� *numeroEjemp+  5      $ Fecha publicacion��6%    6@   �� *fechaPublicacion+  5      $ Estado��6%    65   �� *estado+5      �� 5   
   $��
Ejemplares��6   $
��Left=�6%   $��
387,54,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ 
botonPedir��5      $��Pedir Préstamo��6%   $
��Left=�6>   $��	21,98,0,0q�6Y   $	��Top=�6l   $	��351��6�   $��46��6�   $��16(�6�   6�   5      5      