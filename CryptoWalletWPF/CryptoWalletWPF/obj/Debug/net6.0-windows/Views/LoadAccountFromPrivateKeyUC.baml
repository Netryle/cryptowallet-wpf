   M S B A M L   `   `   `  ����J  FCryptoWalletWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CryptoWalletWPF.ViewsCryptoWalletWPF.Views  5      7    1CryptoWalletWPF.Views.LoadAccountFromPrivateKeyUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CryptoWalletWPF.Views     5      .��5	      � ��5
   
   �� 5        �� ImageSource$W  QD:\GraduateWork\cryptowallet-wpf\CryptoWalletWPF\CryptoWalletWPF\Images\back2.jpg��6   .+�5   
   �� $��Enter your private key��6   $��Center=�61   $��0,94,0,0q�6N   $	��Top=�6`      HeaderStyle#��[  6x   �� 5   
   -   5         ��Name$ enterPrivateKeyTextBox��5      $��Center=�6-   $��	0,172,0,0q�6J    �� TextWrapping$ NoWrap=�6]   $	��Top=�6s   $	��384��6�    �� TextAlignment$ Center=�6�   ��5      �� *
PrivateKey+5   �   �� 5   
   -   5         ��Name$ 
backButton��5   7   $
��Back��6K   $
��Left=�6Z   $��135,244,0,0q�6u   $	��Top=�6�     ButtonStyle#��[ 6�   ��6   �� *backButtonCommand+6�   �� 5   
   -   5        $ 
loadButton��5   7   $
��Load��6K   $��285,244,135,0q�6Z   $	��Top=�6q   #��[ 6�   $��Right=�6�   $	��130��6�   ��6   �� *loadButtonCommand+6�   5      5      