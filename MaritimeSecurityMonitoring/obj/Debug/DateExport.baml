   M S B A M L   `   `   `  ����  MaritimeSecurityMonitoring+    %MaritimeSecurityMonitoring.DateExport   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� ShowsNavigationUI  .   N� 	KeepAlive .   N� Title$ Shujudaochu��5      .��5
      � $
��Auto��6   $
��Auto��6   ��5   
   �� 5       �� ImageSource$! Image/backgroundpicture.png��6    j� Stretch$
 Fill=�6C    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��2��6   $��0��6   $��4��6,    5      �� 5      $
��0.8* �6    �� 5      $
��0.8* �6    �� 5      $
��0.8* �6    �� 5      $
��0.8* �6    �� 5      $��5* �6    �� 5      $
��0.5* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��1.3* �6#   �� 5      $��* �6#   �� 5       $��* �6#   .+�5"      � $��3��6   $��0��6%   $��3��65   $��Center=�6I   $��20,0,0,0q�6d   .+�5#      �� $��0��6   $��0��6%   $��16(�65   $��Center=�6C   $
��Left=�6e   .��6�   导出路径：6�   �� 5$      -   5        $��filePathText��5$   u   
�������$	��300��6-   $��30��69   $��14(�6E   $��Center=�6S   6�   �� 5%      -   5        $��30��5%      $��60��6%   $��Center=�60   $��20,0,0,0q�6R   ���#1e8ab7$��16(�6y   
�������$��Center=�6�   .��6�   选择6�   �� 5&      -   5        $��4��5&      $��3��6&   ���#1e8ab7
�������$��60��6^   $��30��6i   $��Center=�6u   $��Center=�6�   $��16(�6�   $��20,0,0,0q�6�   .��6�   导出6�   5'      � 5(      $��2��6   $��0��6%   $��3��65   $��60��6I   $��Center=�6U   $��20,0,0,0q�6p   .+�5)      �� $��16(�6   $��60��6&   $��Center=�62   .��6T   起止时间：6[   (  "System.Windows.Controls.DatePicker  5*      -   5        $��time1��5*   �   
�������$	��150��60   $��30��6<   $��14(�6H      SelectedDateFormat$ Short=�6V   $��Center=�6q   6�   �� 5+      $��60��6   $��Center=�6$   $��	70,0,70,0q�6F   .��6Y   —6\     5,      -   5        $��time2��5,   �   
�������$	��150��60   $��30��6<   $��14(�6H   $ Short=�6V   $��Center=�6q   6�   5-      � 5.      $��0��6   $��0��6    $��4��60   $��2��6D   $��Center=�6U    5/      �� 50      $��* �6$   �� 51      $��* �6$    53      �� 54      $
��0.8* �6'   �� 55      $��* �6'   �� 56      $��* �6'   �� 57      $��* �6'   �� 58      $��* �6'   �� 59      $��* �6'   .+�5;      �� $��0��6   $��0��6%   $��40��66   $��Center=�6B   $��Center=�6d   $
��Left=�6   $��15(�6�   $��20,0,0,0q�6�   .��6�   态势数据：6�   	� 5<      $��0��6   $��1��6+   $��16(�6;   $��20��6I   $��30,0,0,0q�6U   $��Center=�6g   $��Center=�6�    d� 	IsChecked$
 TrueY�6�   .��6�   AIS6�   	� 5=      $��0��6   $��2��6+   $��16(�6;   $��20��6I   $��	15,0,15,0q�6U   $��Center=�6h   $��Center=�6�   .��6�   雷达6�   	� 5>      $��0��6   $��3��6+   $��16(�6;   $��20��6I   $��	15,0,15,0q�6U   $��Center=�6h   $��Center=�6�   .��6�   光电6�   	� 5?      -   5        $��0��5?      $��4��6+   $��16(�6;   $��20��6I   $��	15,0,15,0q�6U   $��Center=�6h   $��Center=�6�   .��6�   融合6�   �� 5A      $��1��6   $��0��6%   $��40��65   $��Center=�6A   $��Center=�6c   $��15(�6~   $
��Left=�6�   $��20,0,0,0q�6�   .��6�   日志数据：6�   	� 5B      $��1��6   $��1��6+   $��16(�6;   $��20��6I   $��	30,0,15,0q�6U   $��Center=�6h   $��Center=�6�   .��6�   工作日志6�   	� 5C      $��1��6   $��2��6+   $��16(�6;   $��20��6I   $��	15,0,15,0q�6U   $��Center=�6h   $��Center=�6�   .��6�   界面操作日志6�   	� 5D      $��1��6   $��3��6+   $��2��6;   $��16(�6O   $��20��6]   $��	15,0,15,0q�6i   $��Center=�6|   $��Center=�6�   .��6�   用户登录状态管理6�   5E      � 5F      $��4��6   $��0��6%   $��4��65   ��5G      �� 5H      $ Image\DateExport.png��6!   $
 Fill=�6D   5J      5K      5L      5M      