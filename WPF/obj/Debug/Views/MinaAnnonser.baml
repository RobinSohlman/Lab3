   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPF.ViewModels.MinaAnnonserWPF.ViewModels.MinaAnnonser  5   	       WPF.Views.MinaAnnonser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8vm)clr-namespace:WPF.ViewModels.MinaAnnonser     5   	     � Title$  MinaAnnonser��5	   	   $��421.296��6   $��583.739��6/   .��5
      � $��	10,0,0,-1q�6    � ColumnDefinitions 5   
   �� 5      $	��60* �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� Padding$ 10q�6!   $��Mina Annonser��6.    �� TextAlignment$ Center=�6C   $��20(�6Z   $
��Bold"�6h   $��X-Files)�6z   $��2��6�   � 5   
   $��1��6   $��
39,10,0,35q�6    J� RenderTransformOrigin$ 0.524,0.505&�60   $��2��6T    5      �� 5      $��* �6#   .+�5      �� -   5        $��lvUsers��5   T   $��10,10,41,10q�6   ��6,   �� *BostadsAnnonser+ �� SelectedItem 6c   �� *
ValdAnnons+ �� Mode$ TwoWay=� �� View 5      �� 5      .P�5       �� $��AnnonsID��6)   	 �� Width$		 120��6;   
 �� DisplayMemberBinding
 6G   �� *Annons.BostadsAnnonsID+�� 5!      $��Adress��6)   $		 250��69   
 6E   �� *Bostad.Adress+�� 5"      $
��Stad��6)   $		 100��67   
 6C   �� *Bostad.Stad+5#      5%      5&      �� 5(   
   $��2��6   $��Välj��6   $��411,10,50,10q�6-   $��10q�6C   $��2��6�   ��6P   �� *OpenNewHanteraEnAnnonsCommand+6�   5*      5+      