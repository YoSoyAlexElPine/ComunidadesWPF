   M S B A M L   `   `   `  ����F  BComunidades, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ComunidadesComunidades  5   	       Comunidades.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Comunidades     5   	     � Title$,  &Neighborhood association in a building��5   	   $	��587��68   $	��948��6E    � Cursor$	 Pen��5	   	   .��5      �    EstiloGridGeneral#��[  6   .+�5   
   ��   EstiloLabelTitulo#��[ 6   $��Neighborhood Association��6;   $��
331,10,0,0q�6^   � 5   
   $��	0,100,0,0q�6   .+�5      �� -   5         ��Name$ 
tabControl��5   C     EstiloTabControl#��[ 6   $��2��6W   .@�5      ��   EstiloTabItem#��[ 6   $��Make a neigborhood��6A   .��5      ��   EstiloStackPanel#��[ 6!   .+�5      � -   5         �Name$ grid_1��5   C     
EstiloGrid#��[ 6   $y�Visible=�6S   .+�5      �� $��New Neighborhood��6(     EstiloTitulo#��[ 6@   6h   �� 5      $
��Name��6$     EstiloLabel#��[ 63   $��
181,94,0,0q�6X   �� 5      $��Adress��6$   #��[ 65   $��181,145,0,0q�6Z   �� 5      $
��Date��6$   #��[ 63   $��181,200,0,0q�6X   �� 5       $��Meters��6$   #��[ 65   $��181,256,0,0q�6Z   �� 5#      -   5         ��Name$ 	tb_meters��5#   &     EstiloTextBox#��[ 69   $��371,256,0,0q�6`   6�   �� 5$      -   5        $ tb_name��5$   &   #��[ 67   $��
371,93,0,0q�6^    �� TextWrapping$
 Wrap=�6r   6�   �� 5%      -   5        $ 	tb_adress��5%   &   #��[ 69   $��371,145,0,0q�6`   $
 Wrap=�6u   6�   (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ dp_fecha��5'   S    	 EstiloDatePicker#��[	 6)   $��371,200,0,0q�6e   6z   �� 5)      -   5         ��Name$ b_next_1��5)   %    
 EstiloBoton#��[
 67   $
��Next��6\   $��576,382,0,0q�6k   ${�False��6�   6�   5,      � 5.      -   5        $ grid_2��5.   C   #��[ 6   $y�	Collapsed=�6S   .+�50      �� #��[ 6$   $��
Gatekeeper��6I   $��
173,14,0,0q�6^   �� 51      #��[ 6$   $��Shower and toilets
��6I   $��
173,65,0,0q�6k   �� 52      #��[ 6$   $��	Play area��6I   $��173,120,0,0q�6]   �� 53      #��[ 6$   $��Exercise area��6I   $��173,176,0,0q�6a   �� 54      #��[ 6$   $��Meeting room��6I   $��173,227,0,0q�6`   �� 55      #��[ 6$   $��Tennis court��6I   $��173,281,0,0q�6`   �� 56      #��[ 6$   $��Padel court��6I   $��173,332,0,0q�6_   �� 57      #��[ 6$   $
��Pool��6I   $��173,377,0,0q�6X   d� 5;      -	   5         d�Name$ Toggle_gatekeeper��5;   W     EstiloToggleButton#��[ 6+   6W   d� 5<      -
   5        $ Toggle_shower��5<   W   #��[ 6+   $��396,71,212,333q�6n   d� 5=      -   5        $ Toggle_play��5=   W   #��[ 6+   $��396,122,212,282q�6l   d� 5>      -   5        $ Toggle_exercise��5>   W   #��[ 6+   $��396,179,212,225q�6p   d� 5?      -   5        $ Toggle_meeting��5?   W   #��[ 6+   $��396,231,212,173q�6o   d� 5@      -   5        $ Toggle_tenis��5@   W   #��[ 6+   $��396,285,212,119q�6m   d� 5A      -   5        $ Toggle_padel��5A   W   #��[ 6+   $��396,334,212,70q�6m   d� 5B      -   5        $ Toggle_piscina��5B   W   #��[ 6+   $��396,379,212,25q�6o   �� 5F      -   5        $ b_next_2��5F   J   #��[
 6%   $��Finish��6]   $��576,382,0,0q�6n   6�   �� 5G      -   5        $ b_previus_2��5G   J   #��[
 6%   $��Previus��6_   $��500,382,0,0q�6q   6�   5H      5J      5K      �� 5L      -   5        	 ��Name$	 tabItem2��5L   A   #��[ 6   $��Communities��6y   .��5M      �� #��[ 6!   .+�5N      � #��[ 6   .+�5O      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dg_comunidades��5O   Q     MaterialDataGrid#��[ 6'   $��
20,10,0,10q�6i      Columns 5Q   "   0  *System.Windows.Controls.DataGridTextColumn  5R   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Nombre+6T     5S   &   $ 	Direccion��6W      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6j    69   �� *	Direccion+6j     5T   &   $ Fecha��6S   $ * 6b    69   �� *Fecha+6b     5U   &   $ Metros��6T   $ * 6d    69   �� *Metros+6d   4  .System.Windows.Controls.DataGridCheckBoxColumn  5V   &   $ Padel��6W   $ * 6f    6=   �� *Padel+6f     5W   &   $ Tenis��6W   $ * 6f    6=   �� *Tenis+6f     5X   &   $ Meeting��6Y   $ * 6j    6=   �� *	Meeting+6j     5Y   &   $ Exercise��6Z   $ * 6l    6=   �� *
Exercise+6l     5Z   &   $
 Play��6V   $ * 6d    6=   �� *Play+6d     5[   &   $ Shower��6X   $ * 6h    6=   �� *Shower+6h     5\   &   $ Portero��6Y   $ * 6j    6=   �� *	Portero+6j     5]   &   $ Piscina��6Y   $ * 6j    6=   �� *	Piscina+6j   5_      5`      5b      5c      �� 5d      -   5        $	 tabItem_portals��5d   A   #��[ 6   $��Portals��6�   .��5e      �� #��[ 6!   .+�5f      � #��[ 6   .+�5g        -   5        $
 dg_portales��5g   '   #��[ 6<   $��440,32,10,222q�6f   ��6}   �� *Comunidades+ 5h   "     5i   &   $ Id��6V    69   �� *
ProtalId+6V     5j   &   $ 	Escaleras��6W   $ * 6j    69   �� *	Escaleras+6j     5k   &   $ 	Comunidad��6Y   $ * 6l    69   �� *ComunidadId+6l   5n      �� 5p      -   5         ��Name$ cb_comunidades_portals��5p   O     EstiloComboBox#��[ 6'   $��
199,52,0,0q�6o   �� 5r      -   5        $ tb_stairs_portals��5r   Q     EstiloTextBoxLite#��[ 6&   $��
199,97,0,0q�6l   6�   �� 5t      -   5        $ b_refresh_1��5t   J   #��[
 6%   $��Refresh��6_   $��440,273,0,0q�6q   6�   �� 5u      -   5        $ b_save_portals��5u   J   #��[
 6%   $
��Save��6b   $��228,222,0,0q�6q   6�   �� 5w        EstiloTextBlock#��[ 6(   $��	77,52,0,0q�6Q   $��Neigborhood��6d   �� 5x      #��[ 6(   $��	77,93,0,0q�6Q   $��Stairs��6d   �� 5z      #��[ 6(   $
��Left=�6N   $��	21,10,0,0q�6i   $��
New Portal��6|   6�   5{      5}      5~      �� 5      -   5        $	 tabItem_stairs��5   A   #��[ 6   $��Stairs��6�   .��5�      �� #��[ 6!   .+�5�      � #��[ 6   .+�5�        -   5        $
 dg_escaleras��5�   '   #��[ 6=   $��440,32,10,222q�6g   ��6~   �� *Comunidades+ 5�   "     5�   &   $ Nombre��6T    69   �� *Nombre+6T     5�   &   $ 	Direccion��6W   $ * 6j    69   �� *	Direccion+6j     5�   &   $ Fecha��6S   $ * 6b    69   �� *Fecha+6b   5�      �� 5�      -   5        $ cb_comunidades_stairs��5�   O   #��[ 6'   $��
199,52,0,0q�6�   �� 5�      -   5        $ cb_portales_stairs��5�   O   #��[ 6'   $��199,105,0,0q�6k   �� 5�      -   5        $ b_refresh_2��5�   J   #��[
 6%   $��Refresh��6_   $��440,273,0,0q�6q   6�   �� 5�      -    5        $ b_save_stairs��5�   J   #��[
 6%   $
��Save��6b   $��228,222,0,0q�6q   6�   �� 5�      -!   5        $ tb_floors_stairs��5�   Q   #��[ 6&   $��199,162,0,0q�6k   6�   �� 5�      #��[ 6(   $��	77,52,0,0q�6Q   $��Neighborhood��6d   �� 5�      #��[ 6(   $��
77,158,0,0q�6Q   $��Floors��6e   �� 5�      #��[ 6(   $��
77,105,0,0q�6Q   $��Portal��6e   �� 5�      #��[ 6(   $��	21,10,0,0q�6N   $��	New Stair��6a   6t   5�      5�      5�      �� 5�      -"   5        $	 tabItem_floor��5�   A   #��[ 6   $��Floor��6�   .��5�      �� #��[ 6!   .+�5�      � #��[ 6   .+�5�        -#   5        $
 	dg_planta��5�   Q   #��[ 6'   $��440,32,10,222q�6e   ��6|   �� *Comunidades+ 5�   "     5�   &   $ Nombre��6T    69   �� *Nombre+6T     5�   &   $ 	Direccion��6W   $ * 6j    69   �� *	Direccion+6j     5�   &   $ Fecha��6S   $ * 6b    69   �� *Fecha+6b   5�      �� 5�      -$   5        $ cb_comunidades_floor��5�   O   #��[ 6'   $��
199,52,0,0q�6�   �� 5�      -%   5        $ cb_portales_floor��5�   O   #��[ 6'   $��
199,93,0,0q�6�   �� 5�      -&   5        $ cb_escaleras_floor��5�   O   #��[ 6'   $��199,138,0,0q�6k   �� 5�      -'   5        #��[
 5�   %   $��Refresh��6J   $��440,273,0,0q�6\   6q   �� 5�      -(   5        #��[
 5�   %   $
��Save��6J   $��228,222,0,0q�6Z   6o   �� 5�      -)   5        $ tb_apartamentos_floor��5�   Q   #��[ 6&   $��199,173,0,0q�6q   6�   �� 5�      #��[ 6(   $��	77,52,0,0q�6Q   $��Neighborhood��6d   �� 5�      #��[ 6(   $��
77,169,0,0q�6Q   $��
Apartments��6e   �� 5�      #��[ 6(   $��
77,138,0,0q�6Q   $��Stair��6e   �� 5�      #��[ 6(   $��	77,93,0,0q�6Q   $��Portal��6d   �� 5�      #��[ 6(   $��	21,10,0,0q�6N   $��	New Floor��6a   5�      5�      5�      �� 5�      -*   5        $	 tabItem_apartamento��5�   A   #��[ 6   $��	Apartmets��6�   .��5�      �� #��[ 6!   .+�5�      � #��[ 6   $	 Pen��6C   .+�5�        -+   5        $
 dg_apartamentos��5�   '   #��[ 6@   $��440,32,10,222q�6j   ��6�   �� *Comunidades+ 5�   "     5�   &   $ Nombre��6T    69   �� *Nombre+6T     5�   &   $ 	Direccion��6W   $ * 6j    69   �� *	Direccion+6j     5�   &   $ Fecha��6S   $ * 6b    69   �� *Fecha+6b   5�      �� 5�      -,   5        $  cb_comunidades_apartamento��5�   O   #��[ 6'   $��
199,52,0,0q�6�   �� 5�      --   5        $ cb_portales_apartamento��5�   O   #��[ 6'   $��
199,93,0,0q�6�   �� 5�      -.   5        $ cb_escaleras_apartamento��5�   O   #��[ 6'   $��199,138,0,0q�6�   �� 5�      -/   5        $ cb_planta_apartamento��5�   O   #��[ 6'   $��199,175,0,0q�6n   �� 5�      #��[ 6(   $��	77,52,0,0q�6Q   $��Neighborhood��6d   �� 5�      #��[ 6(   $��
77,175,0,0q�6Q   $��Floor��6e   6t   �� 5�      #��[ 6(   $��
77,138,0,0q�6Q   $��Stair��6e   �� 5�      #��[ 6(   $��	77,93,0,0q�6Q   $��Portal��6d   �� 5�      #��[ 6(   $��
77,209,0,0q�6Q   $
��Char��6e   6s   �� 5�      #��[ 6(   $
��Left=�6Q   $��	21,10,0,0q�6l   $��18(�6   $
��Wrap=�6�   $	��Top=�6�   $��27��6�   $	��224��6�   �� 6�    � Language$ es-es�6�   $�New Apartment��6�   6�   �� 5�      -0   5        $ tb_letra_apartamento��5�   Q   #��[ 6&   $��	199,0,0,0q�6�   $��Center=�6�   �� 5�      -1   5        $ b_refresh_apartamento��5�   J   #��[
 6%   $��Refresh��6i   $��440,273,0,0q�6|   6�   �� 5�      -2   5        $ b_save_apartamento��5�   J   #��[
 6%   $
��Save��6f   $��228,273,0,0q�6u   6�   5�      5�      5�      �� 5�      -3   5        $	 tabItem_propietario��5�   A   #��[ 6   $��Owner��6�   .��5�      �� #��[ 6!   .+�5�      � -4   5        $ g_propietario_1��5�   C   #��[ 6   $y�Visible=�6\   .+�5�        -5   5        $
 dg_propietario��5�   '   #��[ 6?   $��440,32,10,222q�6i   ��6�   �� *Comunidades+ 5�   "     5�   &   $ Nombre��6T    69   �� *Nombre+6T     5�   &   $ 	Direccion��6W   $ * 6j    69   �� *	Direccion+6j     5�   &   $ Fecha��6S   $ * 6b    69   �� *Fecha+6b   5�      �� 5�      -6   5        $  cb_comunidades_propietario��5�   '   #��[ 6K   $��
199,52,0,0q�6�   �� 5�      -7   5        $ cb_portales_propietario��5�   '   #��[ 6H   $
��Left=�6�   $��
199,93,0,0q�6�   �� 5�      -8   5        $ cb_escaleras_propietario��5�   '   #��[ 6I   $
��Left=�6�   $��199,138,0,0q�6�   �� 5�      -9   5        $ cb_planta_propietario��5�   '   #��[ 6F   $
��Left=�6�   $��199,175,0,0q�6�   �� 5�      -:   5        $  cb_apartamento_propietario��5�   '   #��[ 6K   $��199,209,0,0q�6�   �� 5     #��[ 6(   $��	77,52,0,0q�6Q   $��Neigborhood��6d   �� 5     #��[ 6(   $��Floor��6Q   $��
77,175,0,0q�6^   �� 5     #��[ 6(   $��Stair��6Q   $��
77,138,0,0q�6^   �� 5     #��[ 6(   $��Portal��6Q   $��	77,93,0,0q�6_   �� 5     #��[ 6(   $��	Apartment��6Q   $��
77,209,0,0q�6b   �� 5     #��[ 6(   $��	21,10,0,0q�6N   $��	New Owner��6a   6t   �� 5     -;   5        #��[
 5  %   $��Refresh��6J   $��440,273,0,0q�6\   6q   �� 5     -<   5        $ b_next_propietario��5  J   #��[
 6%   ${�False��6f   $
��Next��6x   $��228,273,0,0q�6�   6�   5     � 5     -=   5        $ g_propietario_2��5  C   #��[ 6   $y�	Collapsed=�6\   .+�5     �� #��[ 6(   $��	77,66,0,0q�6Q   �� 6e   $ es-es�6i   $	�DNI��6z   6�   �� 5     #��[ 6(   $��
77,169,0,0q�6Q   �� 6f   $ es-es�6j   $�Locality��6{   6�   �� 5     #��[ 6(   $��
77,136,0,0q�6Q   �� 6f   $ es-es�6j   $�Surname��6{   6�   �� 5     #��[ 6(   $��
77,102,0,0q�6Q   �� 6f   $ es-es�6j   $
�Name��6{   6�   �� 5     #��[ 6(   $��
77,209,0,0q�6Q   �� 6f   $ es-es�6j   $�Address��6{   6�   �� 5     #��[ 6(   $��
77,245,0,0q�6Q   �� 6f   $ es-es�6j   $�Postal code��6{   6�   �� 5     #��[ 6(   $��
77,279,0,0q�6Q   �� 6f   $ es-es�6j   $�	Provincia��6{   6�   �� 5     #��[ 6(   $��	21,10,0,0q�6N   $��	New Owner��6a   6t   �� 5     ->   5        $ b_save_propietario��5  J   #��[
 6%   $
��Save��6f   $��228,354,0,0q�6u   6�   �� 5     -?   5        $ b_previus_propietario��5  J   #��[
 6%   $��Previus��6i   $��
77,354,0,0q�6{   6�   �� 5      -@   5        $ tb_cp��5   Q   #��[ 6&   $��173,245,0,0q�6`   6u   �� 5!     -A   5        $ tb_provincia��5!  Q   #��[ 6&   $��173,281,0,0q�6g   �� 5"     -B   5        $ tb_localidad��5"  Q   #��[ 6&   $��173,173,0,0q�6g   �� 5#     -C   5        $ tb_direccion��5#  Q   #��[ 6&   $��173,209,0,0q�6h   �� 5$     -D   5        $ tb_apellido��5$  Q   #��[ 6&   $��173,140,0,0q�6f   �� 5%     -E   5        $ tb_dni��5%  Q   #��[ 6&   $��
173,68,0,0q�6a   �� 5&     -F   5        $ 	tb_nombre��5&  Q   #��[ 6&   $��173,104,0,0q�6f   5(     5)     5*     5+     5,     5-     5.     