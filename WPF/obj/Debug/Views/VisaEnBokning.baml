   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPF.ViewModels.SeparatBokningWPF.ViewModels.SeparatBokning  5   	       WPF.Views.VisaEnBokning   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :vm+clr-namespace:WPF.ViewModels.SeparatBokning     5   	     � Title$  Bokning��5	   	   $��366.76��6   $��456.421��6)   .��5
      � $��0,0,0,2q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� Padding$ 10q�6!   $��Den valda bokningen��6.    �� TextAlignment$ Center=�6I   $��20(�6`   $
��Bold"�6n   $��X-Files)�6�   �� 5   
   -   5        $��listBox1��5   %   $��	42,29,0,0q�6   $
��Left=�65   $	��Top=�6P   $	��214��6h   $	��164��6t   $��1��6�   .@�5      �� ��6   �� *	BostadsId+ �� Mode$ TwoWay=�6G   �� 5      ��6   �� *
BokningsId+$ TwoWay=�6H   �� 5      ��6   �� *
StartDatum+$ TwoWay=�6H   �� 5      ��6   �� *	SlutDatum+$ TwoWay=�6G   5      �� 5   
   -   5        $��button1��5   1   $��23��6   $��
42,233,0,0q�6   $	��Top=�6A   $
��Left=�6Y   $��76��6t   $��1��6�   ��6�   �� *NewTaBortEnBokning+.��6�   Avboka6�   5      5      