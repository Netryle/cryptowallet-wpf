   M S B A M L   `   `   `  ����J  FCryptoWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CryptoWalletWPFCryptoWalletWPF  5      G(clr-namespace:CryptoWalletWPF.ViewModelsCryptoWalletWPF.ViewModels  6:   .    (CryptoWalletWPF.Views.HDWalletCreatingUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CryptoWalletWPF     5      ?
viewmodels(clr-namespace:CryptoWalletWPF.ViewModels     6:   .��5	      � ��5
   
   �� 5        �� ImageSource$W  QD:\GraduateWork\cryptowallet-wpf\CryptoWalletWPF\CryptoWalletWPF\Images\back2.jpg��6   .+�5   
   �� $��Your seed phrase��6   $
��Left=�6+   $��
174,26,0,0q�6F   $	��Top=�6Z      HeaderStyle#��[  6r   �� 5   
   $-��'(Save it for future login and recovery)��6   $��Center=�6B   $��0,64,0,0q�6_   $	��Top=�6q     SmallTextStyle#��[ 6�   �� 5   
   -   5         ��Name$ seedPhraseTextBox��5   2   $
��Left=�6M   $��169,110,0,0q�6h    �� TextWrapping$ NoWrap=�6}   $	��Top=�6�   $	��206��6�   $	��100��6�    �� TextAlignment$ Center=�6�    �� 
IsReadOnly$
 True��6�   $��18(�6�   ��6   �� *MnemonicString+6�   �� 5   
   $��Password��6   $
��Left=�6#   $��169,212,0,0q�6>   $	��Top=�6S     	TextStyle#��[ 6k   �� 5   
   $��Confirm password��6   $
��Left=�6+   $��169,260,0,0q�6F   $	��Top=�6[   #��[ 6s   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��174,246,0,0q�6F   $	��Top=�6[   $	��197��6s   6   G� 5   
   -   5        $ confirmPasswordBox��5      $
��Left=�62   $��174,294,0,0q�6M   $	��Top=�6b   $	��197��6z   6�   �� 5   
   $��Create��69   $��290,326,0,0q�6J     ButtonStyle#��[ 6_   $��36��6�   $	��Top=�6�   $
��Left=�6�   $	��130��6�   ��6   �� *createButtonCommand+6�   �� 5   
   $
��Back��67   $��Right=�6F   $��0,326,290,0q�6b   #��[ 6w   $��36��6�   $	��Top=�6�   ��6   �� *backButtonCommand+6�   �� 5   
   $
��Left=�67   $��380,110,0,0q�6R   $	��Top=�6g     CopyButtonStyle#��[ 6   ��6   �� *copyButtonCommand+��6�   Z� ��6�   Z� .��5      �� $V��PD:\GraduateWork\cryptowallet-wpf\CryptoWalletWPF\CryptoWalletWPF\Images\copy.png��6   $��25��6n   $��25��6y   5      5      5      