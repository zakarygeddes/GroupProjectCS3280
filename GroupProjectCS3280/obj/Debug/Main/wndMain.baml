   M S B A M L   `   `   `  ����M  IGroupProjectCS3280, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GroupProjectCS3280.MainGroupProjectCS3280.Main  5   	   %    GroupProjectCS3280.Main.wndMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:GroupProjectCS3280.Main     5   	     � Title$  wndMain��5   	   $��507.778��6   $	��800��6*   .��5	      � .+�5
   
   o� $
��Left=�6   $��23��6*   $	��Top=�66   $��80��6N   .@�5      m� -   5        $��Options��5      .@�5      m� -   5         m�Name$ ctrlEditItem��5      $��
Edit Items��61    m� IsCheckable . 6E   m� 5      -   5        $ 
ctrlSearch��5      $��Search Invoices��6/    . 6H   5      5      � 5   
   -   5         �Name$ 
gridInputs��5      $
��Left=�6#   $	��420��6>   $��	10,51,0,0q�6K   $	��Top=�6^   $	��779��6v   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgInvoice��5       � DataContext$ items��6*   $
��Left=�6>   $	��234��6Y   $��178,142,0,-42q�6f   $	��Top=�6}   $	��432��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        colDesc��,  &System.Windows.Controls.DataGridColumn   Header$ Description��5   6      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6p   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6K   �� 
 �� Path$
 description�6~     5      -   5        colCost��$
 Cost��5   6   $ 69 6b   	 6D   �� $

 cost�6o   5      �� 5      -   5         ��Name$ lblInvoiceNum��5      $��Invoice Num:��6+   $
��Left=�6B   $��7,95,0,0q�6]   $	��Top=�6o   �� 5      -	   5         ��Name$ txtInvoiceNum��5      $
��Left=�6-   $��23��6H   $��	89,99,0,0q�6T    �� TextWrapping$
 Wrap=�6g   $	��TBD��6{   $	��Top=�6�   $��61��6�   �� 5      -
   5        $ lblDate��5      $��Date:��6%   $
��Left=�65   $��
159,96,0,0q�6P   $	��Top=�6d   �� 5      -   5        $ lblItem��5      $��Item:��6%   $
��Left=�65   $��
326,96,0,0q�6P   $	��Top=�6d   �� 5      -   5         ��Name$ cmbItems��5      $
��Left=�6)   $��
377,99,0,0q�6D   $	��Top=�6X   $	��120��6p   6|   �� 5      -   5        $ lblCost��5      $��Cost:��6%   $
��Left=�65   $��
502,97,0,0q�6P   $	��Top=�6d   �� 5      -   5        $ txtCost��5       �� 
IsReadOnly . $
��Left=�69   $��23��6T   $��
543,99,0,0q�6`   $
 Wrap=�6t   $��$��6�   $	��Top=�6�   $	��120��6�   �� 5      -   5         ��Name$ btnEnter��5      $��Enter��6'   $
��Left=�67   $��
688,99,0,0q�6R   $	��Top=�6f   $��79��6~   $��23��6�   6�   �� 5      -   5        $ btnSave��5      $
��Save��6&   $
��Left=�65   $��363,392,0,-78q�6P   $	��Top=�6g   $��75��6   6�   (  "System.Windows.Controls.DatePicker  5       -   5          Name$ 
DatePicker��5       $
��Left=�6-   $��
201,98,0,0q�6H   $	��Top=�6\   �� 5!      -   5        $ lblTotalCost��5!      $��Total Cost: $��6*   $
��Left=�6B   $��178,389,0,0q�6]   $	��Top=�6r   �� 5"      -   5        $ lblTotalCostNum��5"      $��0��6-   $
��Left=�69   $��263,389,0,0q�6T   $	��Top=�6i   �� 5#      -   5        $ btnDeleteLine��5#      $y�Hidden=�6,   $��Delete Line��6A   $
��Left=�6W   $��663,257,0,0q�6r   $	��Top=�6�   $��75��6�   6�   5$      �� 5%   
   -   5        $ btnNewInvoice��5%      $��New Invoice��6(   $
��Left=�6>   $��
131,51,0,0q�6Y   $	��Top=�6m   $	��137��6�   6�   �� 5&   
   -   5        $ btnEditInvoice��5&      $��Edit Invoice��6)   $
��Left=�6@   $��
307,51,0,0q�6[   $	��Top=�6o   $	��123��6�   6�   �� 5'   
   -   5        $ btnDeleteInvoice��5'      $��Delete Invoice��6+   $
��Left=�6D   $��
487,51,0,0q�6_   $	��Top=�6s   $	��142��6�   6�   5)      5*      