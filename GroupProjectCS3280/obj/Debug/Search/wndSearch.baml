   M S B A M L   `   `   `  ����M  IGroupProjectCS3280, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GroupProjectCS3280.SearchGroupProjectCS3280.Search  5   	   )    #GroupProjectCS3280.Search.wndSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:GroupProjectCS3280.Search     5   	   -   5          � Title$  	wndSearch��5   	   $	��500��6   $	��500��6(    � 
ResizeMode$ NoResize=�64   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ SearchDataGrid��5
      $
��Left=�6+   $	��333��6F   $��7,66,0,0q�6S   $	��Top=�6e   $	��474��6}      
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ SelectButton��5      $��SELECT��6'   $
��Left=�68   $��
80,409,0,0q�6S   $	��Top=�6g   $��93��6   $��39��6�    J� RenderTransformOrigin$ 0.538,0.395&�6�   6�   �� 5   
   -   5        $ CancelButton��5      $��CANCEL��6'   $
��Left=�68   $��316,409,0,0q�6S   $	��Top=�6h   $��93��6�   $��39��6�   6�   �� 5   
   -   5         ��Name$ InvoiceNumberBox��5      $
��Left=�6-   $��	35,29,0,0q�6H   $	��Top=�6[   $	��120��6s   6   �� 5   
   -   5        $ InvoiceDateBox��5      $
��Left=�6+   $��
187,29,0,0q�6F   $	��Top=�6Z   $	��120��6r   6~   �� 5   
   -   5        $ TotalChargeBox��5      $
��Left=�6+   $��
341,29,0,0q�6F   $	��Top=�6Z   $	��120��6r   6~   �� 5   
   -   5         ��Name$ lblInvoiceNum��5      $��Invoice Number��6'   $
��Left=�6@   $��47,3,0,0q�6[   $	��Top=�6m   $	��111��6�   $
��Bold"�6�   �� 5   
   -	   5        $ lblDate��5      $
��Date��6!   $
��Left=�60   $��	228,3,0,0q�6K   $	��Top=�6^   $��73��6v   $
��Bold"�6�   �� 5   
   -
   5        $ lblTotalCost��5      $��
Total Cost��6&   $
��Left=�6;   $��	365,3,0,0q�6V   $	��Top=�6i   $��73��6�   $
��Bold"�6�   �� 5   
   -   5        $ ResetButton��5      $��RESET SEARCH��6&   $
��Left=�6=   $��198,409,0,0q�6X   $	��Top=�6m   $��93��6�   $��39��6�   6�   5      5      