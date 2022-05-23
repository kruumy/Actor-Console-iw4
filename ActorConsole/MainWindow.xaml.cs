using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ActorConsole
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Global Vars
        Classes.ExternalConsole Econsole = new Classes.ExternalConsole();
        Brush statusBarColor = new SolidColorBrush(Color.FromRgb(30, 144, 255));
        private string SelectedGun = "NONE";
        int totalActorNum = 0;
        bool forceCheck = false;
        #endregion
        #region Window
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(CheckGameStatus);

            if (File.Exists("settings.ini"))
            {
                precacheBtn.Visibility = Visibility.Hidden;
                precacheBox.Text = File.ReadAllLines("settings.ini")[0];
            }

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (forceCheck || IsGameConnected())
            {
                if (MessageBox.Show("Are you sure you want to quit?\nYou will lose all your current actor data.", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel, MessageBoxOptions.None) == MessageBoxResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
        #region GameStatus
        private void CheckGameStatus()
        {

            while (true)
            {
                if (forceCheck || IsGameConnected())
                {
                    if (forceCheck || IsInGame())
                    {
                        Dispatcher.Invoke(() =>
                        {
                            StatusText.Text = $"Status: Connected - {Classes.MemoryFuncs.GetCurrentMap()}";
                            if (forceCheck || precacheBox.Text.Contains("_precache.gsc"))
                            {
                                createActorBtn.IsEnabled = true;
                                teleportActorBtn.IsEnabled = true;
                                deleteActorBtn.IsEnabled = true;
                                ComboActorNum.IsEnabled = true;
                                sendAllActorBtn.IsEnabled = true;
                                sendAnimsBtn.IsEnabled = true;
                                sendWeaponsBtn.IsEnabled = true;
                                sendModelsBtn.IsEnabled = true;
                                backActorBtn.IsEnabled = true;
                                autosendCheck.IsEnabled = true;
                                modelsItem.IsEnabled = true;
                                animsItem.IsEnabled = true;
                                miscItem.IsEnabled = true;
                                bindsItem.IsEnabled = true;
                                weaponsItem.IsEnabled = true;
                            }
                        });
                    }
                    else
                    {
                        if (forceCheck || IsGameConnected())
                        {
                            Dispatcher.Invoke(() =>
                            {
                                Reset();
                                StatusText.Text = "Status: Connected - Not In Game";
                            });
                        }
                        else
                        {
                            Dispatcher.Invoke(() =>
                            {
                                Reset();
                                StatusText.Text = "Status: Waiting For Game...";
                            });
                        }
                    }
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        Reset();
                        StatusText.Text = "Status: Waiting For Game...";
                    });
                }
                System.Threading.Thread.Sleep(1500);
            }
        }
        private bool IsGameConnected()
        {
            Process[] processesiw4x = Process.GetProcessesByName("iw4x");
            Process[] processesiw4m = Process.GetProcessesByName("iw4m");
            if (processesiw4m.Length == 0)
            {
                if (processesiw4x.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool IsInGame()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                Memory.Win32.MemoryHelper32 m4x;
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "iw4x" || process.ProcessName == "iw4m")
                    {
                        m4x = new Memory.Win32.MemoryHelper32(process);
                        int ingame = m4x.ReadMemory<Int32>(0x7F0F88);
                        if (ingame == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void Reset()
        {
            totalActorNum = 0;
            SelectedGun = "NONE";
            ComboActorNum.Items.Clear();
            deathAnimBox.Items.Clear();
            idleAnimBox.Items.Clear();
            spAnimBox.Items.Clear();
            headBox.Items.Clear();
            bodyBox.Items.Clear();
            spBox.Items.Clear();
            cfgTextBox.Text = "";
            singleSendBox.Text = "";
            selectedBody.Text = "";
            mapBox.Text = "";
            ComboWeaponBone.Text = "j_gun";
            currentIdleAnimBox.Text = "";
            currentDeathAnimBox.Text = "";
            createActorBtn.IsEnabled = false;
            teleportActorBtn.IsEnabled = false;
            deleteActorBtn.IsEnabled = false;
            backActorBtn.IsEnabled = false;
            ComboActorNum.IsEnabled = false;
            sendAllActorBtn.IsEnabled = false;
            sendAnimsBtn.IsEnabled = false;
            sendWeaponsBtn.IsEnabled = false;
            sendModelsBtn.IsEnabled = false;
            autosendCheck.IsEnabled = false;
            autosendCheck.IsChecked = false;
            modelsItem.IsEnabled = false;
            animsItem.IsEnabled = false;
            miscItem.IsEnabled = false;
            bindsItem.IsEnabled = false;
            weaponsItem.IsEnabled = false;
            mainTabs.SelectedIndex = 0;
        }
        private void StatusText_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (forceCheck)
            {
                forceCheck = false;
                statusBar.Fill = statusBarColor;
            }
            else
            {
                if (MessageBox.Show("This is forces the console believe that you connected to MW2 and are in a game. This could cause some issues if you are not. Only use this if it does not automatically detect.", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel, MessageBoxOptions.None) == MessageBoxResult.OK)
                {
                    forceCheck = true;
                    statusBar.Fill = Brushes.Red;
                }
                else
                {
                    forceCheck = false;
                    statusBar.Fill = statusBarColor;
                }
            }
        }
        #endregion
        #region Weapons Tab
        #region ARChecks
        private void M4A1check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M4A1");
        }

        private void FAMAScheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("FAMAS");
        }

        private void SCARHcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("SCARH");
        }

        private void TAR21check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("TAR21");
        }

        private void FALcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("FAL");
        }

        private void M16A4check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M16A4");
        }

        private void ACRcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("ACR");
        }

        private void F2000check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("F2000");
        }

        private void AK47check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("AK47");
        }
        private void MP5Kcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("MP5K");
        }

        private void UMP45check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("UMP45");
        }

        private void Vectorcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Vector");
        }

        private void P90check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("P90");
        }

        private void MiniUzicheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("MiniUzi");
        }

        private void AK47Ucheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("AK47U");
        }

        private void Peacekeepercheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Peacekeeper");
        }

        private void L86LSWcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("L86LSW");
        }

        private void RPDcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("RPD");
        }

        private void MG4check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("MG4");
        }

        private void AUGcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("AUG");
        }

        private void M240check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M240");
        }

        private void Interventioncheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Intervention");
        }

        private void Barrett50check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Barrett50");
        }

        private void WA2000check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("WA2000");
        }

        private void M21EBRcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M21EBR");
        }

        private void M40A3check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M40A3");
        }

        private void Dragunovcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Dragunov");
        }

        private void SPAS12check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("SPAS12");
        }

        private void AA12check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("AA12");
        }

        private void Strikercheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Striker");
        }

        private void Rangercheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Ranger");
        }

        private void M1014check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M1014");
        }

        private void Model1887check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Model1887");
        }

        private void PP2000check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("PP2000");
        }

        private void G18check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("G18");
        }

        private void M93Rcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M93R");
        }

        private void TMPcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("TMP");
        }

        private void USP45check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("USP45");
        }

        private void Magnumcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Magnum");
        }

        private void M9check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("M9");
        }

        private void DesertEaglecheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("DesertEagle");
        }

        private void DesertEagleGoldcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("DesertEagleGold");
        }

        private void AT4check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("AT4check");
        }

        private void Thumpercheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Thumper");
        }

        private void Stingercheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Stinger");
        }

        private void Javelincheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Javelin");
        }

        private void RPGcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("RPG");
        }

        private void RiotShieldcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("RiotShield");
        }

        private void Fragcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Frag");
        }

        private void Semtexcheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Semtex");
        }

        private void Claymorecheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("Claymore");
        }

        private void C4check_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("C4");
        }

        private void SmokeGrenadecheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("SmokeGrenade");
        }

        private void StunGrenadecheck_Checked(object sender, RoutedEventArgs e)
        {
            OneCheck("StunGrenade");
        }
        #endregion
        private void OneCheck(string gun)
        {
            System.Windows.Controls.CheckBox[] gunChecks = { AK47check, F2000check, ACRcheck, M16A4check, FALcheck, TAR21check, SCARHcheck, FAMAScheck, M4A1check,
            MP5Kcheck,UMP45check,Vectorcheck,P90check,MiniUzicheck,AK47Ucheck,Peacekeepercheck,
            L86LSWcheck,RPDcheck,MG4check,AUGcheck,M240check,
            Interventioncheck,Barrett50check,WA2000check,M21EBRcheck,M40A3check,Dragunovcheck,
            SPAS12check,AA12check,Strikercheck,Rangercheck,M1014check,Model1887check,
            PP2000check,G18check,M93Rcheck,TMPcheck,USP45check,Magnumcheck,M9check,DesertEaglecheck,DesertEagleGoldcheck,
            AT4check,Thumpercheck,Stingercheck,Javelincheck,RPGcheck,RiotShieldcheck,Fragcheck,Semtexcheck,Claymorecheck,C4check,SmokeGrenadecheck,StunGrenadecheck};

            switch (gun)
            {
                #region AR
                case "M4A1":
                    {
                        SelectedGun = "m4";
                        Console.WriteLine("m4");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M4A1check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "FAMAS":
                    {
                        SelectedGun = "famas";
                        Console.WriteLine("famas");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != FAMAScheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "SCARH":
                    {
                        SelectedGun = "scar";
                        Console.WriteLine("scar");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != SCARHcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "TAR21":
                    {
                        SelectedGun = "tavor";
                        Console.WriteLine("tavor");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != TAR21check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "FAL":
                    {
                        SelectedGun = "fal";
                        Console.WriteLine("fal");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != FALcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M16A4":
                    {
                        SelectedGun = "m16";
                        Console.WriteLine("m16");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M16A4check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "ACR":
                    {
                        SelectedGun = "masada";
                        Console.WriteLine("masada");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != ACRcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "F2000":
                    {
                        SelectedGun = "fn2000";
                        Console.WriteLine("fn2000");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != F2000check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "AK47":
                    {
                        SelectedGun = "ak47";
                        Console.WriteLine("ak47");

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != AK47check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                #region Submachine
                case "MP5K":
                    {
                        SelectedGun = "mp5k";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != MP5Kcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "UMP45":
                    {
                        SelectedGun = "ump45";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != UMP45check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Vector":
                    {
                        SelectedGun = "kriss";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Vectorcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "P90":
                    {
                        SelectedGun = "p90";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != P90check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "MiniUzi":
                    {
                        SelectedGun = "uzi";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != MiniUzicheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "AK47U":
                    {
                        SelectedGun = "ak74u";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != AK47Ucheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Peacekeeper":
                    {
                        SelectedGun = "peacekeeper";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Peacekeepercheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                #region LMG
                case "L86LSW":
                    {
                        SelectedGun = "sa80";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != L86LSWcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "RPD":
                    {
                        SelectedGun = "rpd";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != RPDcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "MG4":
                    {
                        SelectedGun = "mg4";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != MG4check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "AUG":
                    {
                        SelectedGun = "aug";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != AUGcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M240":
                    {
                        SelectedGun = "m240";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M240check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                #region SNIPER
                case "Intervention":
                    {
                        SelectedGun = "cheytac";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Interventioncheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Barrett50":
                    {
                        SelectedGun = "barrett";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Barrett50check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "WA2000":
                    {
                        SelectedGun = "wa2000";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != WA2000check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M21EBR":
                    {
                        SelectedGun = "m21";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M21EBRcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M40A3":
                    {
                        SelectedGun = "m40a3";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M40A3check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Dragunov":
                    {
                        SelectedGun = "dragunov";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Dragunovcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                #region SHotty
                case "SPAS12":
                    {
                        SelectedGun = "spas12";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != SPAS12check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "AA12":
                    {
                        SelectedGun = "aa12";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != AA12check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Striker":
                    {
                        SelectedGun = "striker";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Strikercheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Ranger":
                    {
                        SelectedGun = "ranger";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Rangercheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M1014":
                    {
                        SelectedGun = "m1014";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M1014check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Model1887":
                    {
                        SelectedGun = "model1887";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Model1887check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                #region Pistol
                case "PP2000":
                    {
                        SelectedGun = "pp2000";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != PP2000check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "G18":
                    {
                        SelectedGun = "glock";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != G18check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M93R":
                    {
                        SelectedGun = "beretta393";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M93Rcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "TMP":
                    {
                        SelectedGun = "tmp";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != TMPcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "USP45":
                    {
                        SelectedGun = "usp";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != USP45check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Magnum":
                    {
                        SelectedGun = "coltanaconda";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Magnumcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "M9":
                    {
                        SelectedGun = "beretta";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != M9check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "DesertEagle":
                    {
                        SelectedGun = "deserteagle";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != DesertEaglecheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "DesertEagleGold":
                    {
                        SelectedGun = "deserteaglegold";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != DesertEagleGoldcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                #region Misc
                case "AT4":
                    {
                        SelectedGun = "at4";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != AT4check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Thumper":
                    {
                        SelectedGun = "m79";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Thumpercheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Stinger":
                    {
                        SelectedGun = "stinger";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Stingercheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Javelin":
                    {
                        SelectedGun = "javelin";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Javelincheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "RPG":
                    {
                        SelectedGun = "rpg";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != RPGcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "RiotShield":
                    {
                        SelectedGun = "riotshield";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != RiotShieldcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Frag":
                    {
                        SelectedGun = "frag_grenade";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Fragcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Semtex":
                    {
                        SelectedGun = "semtex";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Semtexcheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "Claymore":
                    {
                        SelectedGun = "claymore";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != Claymorecheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "C4":
                    {
                        SelectedGun = "c4";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != C4check)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "SmokeGrenade":
                    {
                        SelectedGun = "smoke_grenade";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != SmokeGrenadecheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                case "StunGrenade":
                    {
                        SelectedGun = "concussion_grenade";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            if (guncheck != StunGrenadecheck)
                            {
                                guncheck.IsChecked = false;
                            }
                            else
                            {
                                guncheck.IsChecked = true;
                            }
                        }
                        break;
                    }
                #endregion
                default:
                    {
                        break;
                    }
            }
            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendWeapons();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void sendWeaponsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text != "")
            {
                SendWeapons();
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SendWeapons()
        {
            Econsole.Send($"mvm_actor_weapon {ComboActorNum.Text} {ComboWeaponBone.Text} {SelectedGun}_mp");
        }

        #endregion
        #region Misc Buttons

        private void createActorBtn_Click(object sender, RoutedEventArgs e)
        {
            totalActorNum++;
            ComboActorNum.Items.Add($"actor{totalActorNum}");
            Console.WriteLine($"Created actor{totalActorNum}");
            Econsole.Send("mvm_actor_spawn defaultactor defaultactor");
            ComboActorNum.SelectedItem = $"actor{totalActorNum}";
        }

        private void teleportActorBtn_click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text != "")
            {
                Econsole.Send($"mvm_actor_move {ComboActorNum.Text}");
                Console.WriteLine($"Moved {ComboActorNum.SelectedItem}");
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteActorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text != "")
            {
                Econsole.Send($"mvm_actor_delete {ComboActorNum.Text}");
                Console.WriteLine($"Deleted {ComboActorNum.Text}");
                ComboActorNum.Items.Remove(ComboActorNum.SelectedItem);
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void sendAllActorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text != "")
            {
                SendWeapons();
                SendAnims();
                SendModels();
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void precacheBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePrecache();
        }
        private void ChangePrecache()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GSC files (*.gsc)|*.gsc";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName.Contains("precache.gsc"))
                {
                    precacheBox.Text = openFileDialog.FileName;
                    File.WriteAllText("settings.ini", openFileDialog.FileName);
                    precacheBtn.Visibility = Visibility.Hidden;

                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Enter A '_precache.gsc'", "Error");
                }

            }
        }
        private void precacheBox_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (precacheBox.Text != "No Precache Selected" && MessageBox.Show("This will reset your selected precache. OK?", "Info", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                precacheBox.Text = "No Precache Selected";
                precacheBtn.Visibility = Visibility.Visible;
                if (File.Exists("settings.ini"))
                {
                    File.Delete("settings.ini");
                }
            }
        }
        #endregion
        #region Anims Tab
        private void animsItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (deathAnimBox.Items.Count == 0 || idleAnimBox.Items.Count == 0 || spAnimBox.Items.Count == 0)
            {
                deathAnimBox.Items.Clear();
                idleAnimBox.Items.Clear();
                spAnimBox.Items.Clear();

                string[] mpAnims = Classes.precache.GetMPAnimsFromDir(precacheBox.Text);
                string[] spAnims = Classes.precache.GetSPAnimsFromDir(precacheBox.Text);
                string[] mpDeathAnims = Classes.precache.GetMPDeathAnims(mpAnims);
                string[] mpIdleAnims = Classes.precache.GetMPIdleAnims(mpAnims);

                foreach (string anim in mpDeathAnims)
                {
                    deathAnimBox.Items.Add(anim);
                }
                foreach (string anim in mpIdleAnims)
                {
                    idleAnimBox.Items.Add(anim);
                }
                foreach (string anim in spAnims)
                {
                    spAnimBox.Items.Add(anim);
                }
            }
        }

        private void idleAnimBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            currentIdleAnimBox.Text = idleAnimBox.SelectedItem.ToString();

            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendAnims();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deathAnimBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentDeathAnimBox.Text = deathAnimBox.SelectedItem.ToString();
            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendAnims();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void spAnimBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (spAnimSwitch.IsOn)
            {
                currentIdleAnimBox.Text = spAnimBox.SelectedItem.ToString();
            }
            else if (!spAnimSwitch.IsOn)
            {
                currentDeathAnimBox.Text = spAnimBox.SelectedItem.ToString();
            }
            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendAnims();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void sendAnimsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text != "")
            {
                SendAnims();
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SendAnims()
        {
            Econsole.Send($"mvm_actor_anim {ComboActorNum.Text} {currentIdleAnimBox.Text}");
            Econsole.Send($"mvm_actor_death {ComboActorNum.Text} {currentDeathAnimBox.Text}");
        }
        #endregion
        #region Models Tab
        private void modelsItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (spBox.Items.Count == 0)
            {
                spBox.Items.Clear();
                string[] spModels = Classes.precache.GetSPModelsFromDir(precacheBox.Text);
                foreach (string model in spModels)
                {
                    spBox.Items.Add(model);
                }
            }
            if (headBox.Items.Count == 0 || bodyBox.Items.Count == 0 || mapBox.Text == "")
            {
                mapBox.Text = Classes.MemoryFuncs.GetCurrentMap();
                RefreshModels();
            }

        }

        private void RefreshModels()
        {
            headBox.Items.Clear();
            bodyBox.Items.Clear();
            switch (mapBox.Text)
            {
                case "mp_afghan":
                    {
                        foreach (string h in Classes.PlayerModels.AFGHAN("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.AFGHAN("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_estate":
                    {
                        foreach (string h in Classes.PlayerModels.ESTATE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.ESTATE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_derail":
                    {
                        foreach (string h in Classes.PlayerModels.DERAIL("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.DERAIL("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_favela":
                    {
                        foreach (string h in Classes.PlayerModels.FAVELA("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.FAVELA("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_highrise":
                    {
                        foreach (string h in Classes.PlayerModels.HIGHRISE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.HIGHRISE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_invasion":
                    {
                        foreach (string h in Classes.PlayerModels.INVASION("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.INVASION("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_checkpoint":
                    {
                        foreach (string h in Classes.PlayerModels.CHECKPOINT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CHECKPOINT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_karachi":
                    {
                        foreach (string h in Classes.PlayerModels.KARACHI("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.KARACHI("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_quarry":
                    {
                        foreach (string h in Classes.PlayerModels.QUARRY("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.QUARRY("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_rundown":
                    {
                        foreach (string h in Classes.PlayerModels.RUNDOWN("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.RUNDOWN("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_rust":
                    {
                        foreach (string h in Classes.PlayerModels.RUST("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.RUST("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_boneyard":
                    {
                        foreach (string h in Classes.PlayerModels.SCRAPYARD("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.SCRAPYARD("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_nightshift":
                    {
                        foreach (string h in Classes.PlayerModels.NIGHTSHIFT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.NIGHTSHIFT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_skidrow":
                    {
                        foreach (string h in Classes.PlayerModels.SKIDROW("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.SKIDROW("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_subbase":
                    {
                        foreach (string h in Classes.PlayerModels.SUBBASE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.SUBBASE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_terminal":
                    {
                        foreach (string h in Classes.PlayerModels.TERMINAL("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.TERMINAL("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_underpass":
                    {
                        foreach (string h in Classes.PlayerModels.UNDERPASS("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.UNDERPASS("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_brecourt":
                    {
                        foreach (string h in Classes.PlayerModels.BRECOURT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.BRECOURT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_wasteland":
                    {
                        foreach (string h in Classes.PlayerModels.WASTELAND("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.WASTELAND("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_abandon":
                    {
                        foreach (string h in Classes.PlayerModels.ABANDON("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.ABANDON("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_carnival":
                    {
                        foreach (string h in Classes.PlayerModels.CARNIVAL("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CARNIVAL("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_fuel2":
                    {
                        foreach (string h in Classes.PlayerModels.FUEL2("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.FUEL2("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_fuel":
                    {
                        foreach (string h in Classes.PlayerModels.FUEL("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.FUEL("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_trailerpark":
                    {
                        foreach (string h in Classes.PlayerModels.TRAILERPARK("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.TRAILERPARK("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_strike":
                    {
                        foreach (string h in Classes.PlayerModels.STRIKE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.STRIKE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_vacant":
                    {
                        foreach (string h in Classes.PlayerModels.VACANT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.VACANT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_crash":
                    {
                        foreach (string h in Classes.PlayerModels.CRASH("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CRASH("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_overgrown":
                    {
                        foreach (string h in Classes.PlayerModels.OVERGROWN("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.OVERGROWN("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_complex":
                    {
                        foreach (string h in Classes.PlayerModels.COMPLEX("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.COMPLEX("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_bailout":
                    {
                        foreach (string h in Classes.PlayerModels.BAILOUT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.BAILOUT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_salvage":
                    {
                        foreach (string h in Classes.PlayerModels.SALVAGE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.SALVAGE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_compact":
                    {
                        foreach (string h in Classes.PlayerModels.COMPACT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.COMPACT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_storm":
                    {
                        foreach (string h in Classes.PlayerModels.STORM("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.STORM("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_nuked":
                    {
                        foreach (string h in Classes.PlayerModels.NUKETOWN("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.NUKETOWN("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_bloc":
                    {
                        foreach (string h in Classes.PlayerModels.BLOC("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.BLOC("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_bog_sh":
                    {
                        foreach (string h in Classes.PlayerModels.BLOC("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.BLOC("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_cross_fire":
                    {
                        foreach (string h in Classes.PlayerModels.CROSSFIRE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CROSSFIRE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_killhouse":
                    {
                        foreach (string h in Classes.PlayerModels.KILLHOUSE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.KILLHOUSE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_cargoship":
                    {
                        foreach (string h in Classes.PlayerModels.CARGOSHIP("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CARGOSHIP("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_estate_tropical": // assumed
                    {
                        foreach (string h in Classes.PlayerModels.ESTATE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.ESTATE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_fav_tropical": // assumed
                    {
                        foreach (string h in Classes.PlayerModels.FAVELA("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.FAVELA("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_crash_trop": // assumed
                    {
                        foreach (string h in Classes.PlayerModels.CRASH("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CRASH("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_storm_spring": // assumed
                    {
                        foreach (string h in Classes.PlayerModels.STORM("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.STORM("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_cargoship_sh":
                    {
                        foreach (string h in Classes.PlayerModels.CARGOSHIPSH("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.CARGOSHIPSH("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_shipment":
                    {
                        foreach (string h in Classes.PlayerModels.SHIPMENT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.SHIPMENT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_shipment_long":
                    {
                        foreach (string h in Classes.PlayerModels.SHIPMENT("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.SHIPMENT("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_rust_long": // assumed
                    {
                        foreach (string h in Classes.PlayerModels.RUST("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.RUST("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_firingrange":
                    {
                        foreach (string h in Classes.PlayerModels.FIRINGRANGE("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.FIRINGRANGE("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "mp_bloc_sh":
                    {
                        foreach (string h in Classes.PlayerModels.BLOC("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.BLOC("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                case "oilrig":
                    {
                        foreach (string h in Classes.PlayerModels.OILRIG("head"))
                        {
                            headBox.Items.Add(h.Trim());
                        }
                        foreach (string b in Classes.PlayerModels.OILRIG("body"))
                        {
                            bodyBox.Items.Add(b.Trim());
                        }
                        break;
                    }
                default:
                    {
                        headBox.Items.Clear();
                        bodyBox.Items.Clear();
                        break;
                    }
            }
        }
        private void bodyBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            selectedBody.Text = bodyBox.SelectedItem.ToString();
            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendModels();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void headBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            selectedHead.Text = headBox.SelectedItem.ToString();
            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendModels();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void sendModelsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text != "")
            {
                SendModels();
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SendModels()
        {
            Econsole.Send($"mvm_actor_model {ComboActorNum.Text} {selectedBody.Text} {selectedHead.Text}");
        }

        private void mapBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            RefreshModels();
        }

        private void spBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!spModelSwitch.IsOn)
            {
                selectedBody.Text = spBox.SelectedItem.ToString();
            }
            else if (spModelSwitch.IsOn)
            {
                selectedHead.Text = spBox.SelectedItem.ToString();
            }
            if ((bool)autosendCheck.IsChecked)
            {
                if (ComboActorNum.Text != "")
                {
                    SendModels();
                }
                else
                {
                    ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        #endregion
        #region Pathing Tab
        private void addBindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (directionBindBox.Text == "" || actorNumBindBox.Text == "" || keyBind.Text == "" || speedBind.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(keyBind.Text, "^[a-zA-Z]"))
            {
                ModernWpf.MessageBox.Show("Please Fill In Boxes Correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (var i in allBindsList.Items)
            {
                if (i.ToString() == null)
                {
                    return;
                }
                foreach (string j in i.ToString().Split(','))
                {
                    if (keyBind.Text.ToUpper().Trim() == j.Trim())
                    {
                        ModernWpf.MessageBox.Show("Please Do Not Enter A Duplicate Keybind", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }


            allBindsList.Items.Add($"{actorNumBindBox.Text}, {keyBind.Text.ToUpper()}, {directionBindBox.Text}, {speedBind.Text}");
            Econsole.Send($"bind {keyBind.Text} \"mvm_actor_walk {actorNumBindBox.Text} {speedBind.Text} {directionBindBox.Text}\"");
        }

        private void bindsItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            actorNumBindBox.ItemsSource = ComboActorNum.Items;
        }
        private void removeBindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (allBindsList.Items.Count == 0)
            {
                ModernWpf.MessageBox.Show("No Items In List To Remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            try
            {
                foreach (string i in allBindsList.SelectedItem.ToString().Split(','))
                {
                    if (i.Trim().Length < 2)
                    {
                        Econsole.Send($"bind {i} say ");
                        allBindsList.Items.Remove(allBindsList.SelectedItem);
                    }
                }
            }
            catch
            {
            }
        }

        #endregion
        #region Console Tab
        private void miscItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void sendCfgBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (string line in cfgTextBox.Text.Split('\n'))
            {
                if (!line.Contains("//"))
                {
                    // find way to run on different thread without errors
                    Econsole.Send(line);
                }
            }
        }

        private void loadCfgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "cfg files (*.cfg)|*.cfg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    cfgTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                }
                catch
                {
                }
            }


        }
        #endregion
    }
}
