using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MessageBox = System.Windows.MessageBox;

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
            if (Classes.ProcessFuncs.IsConsoleAlreadyRunning())
            {
                if (MessageBox.Show("Another instance of Actor Console detected, Would You Like To Continue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.No)
                {
                    Environment.Exit(0);
                }
            }

            if (Classes.UpdateChecker.CheckForUpdates(versionText.Text))
            {
                versionText.Text = $"{versionText.Text}, New Version Available!";
            }
            else
            {
                versionText.Text = $"{versionText.Text}, No Updates Available!";
            }



            Task.Run(CheckGameStatus);

            if (File.Exists("settings.ini"))
            {
                precacheBtn.Visibility = Visibility.Hidden;
                precacheBox.Text = File.ReadAllLines("settings.ini")[0];
            }

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (forceCheck || Classes.ProcessFuncs.IsGameConnected())
            {
                if (MessageBox.Show("Are you sure you want to quit?\nYou will lose all your current actor data.", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel, MessageBoxOptions.None) == MessageBoxResult.OK)
                {
                    Reset();
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
                if (forceCheck || Classes.ProcessFuncs.IsGameConnected())
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
                                removeWeaponsBtn.IsEnabled = true;
                                otherTab.IsEnabled = true;
                                sunControllerTab.IsEnabled = true;
                                sendModelsBtn.IsEnabled = true;
                                backActorBtn.IsEnabled = true;
                                autosendCheck.IsEnabled = true;
                                sunCheckBox.IsEnabled = true;
                                modelsItem.IsEnabled = true;
                                demoRecording.IsEnabled = true;
                                animsItem.IsEnabled = true;
                                miscItem.IsEnabled = true;
                                bindsItem.IsEnabled = true;
                                weaponsItem.IsEnabled = true;
                            }
                        });
                    }
                    else
                    {
                        if (forceCheck || Classes.ProcessFuncs.IsGameConnected())
                        {
                            Dispatcher.Invoke(() =>
                            {
                                Reset();
                                miscItem.IsEnabled = true;
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
                            process.Dispose();
                            return false;
                        }
                        else
                        {
                            process.Dispose();
                            return true;
                        }
                    }
                    process.Dispose();
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
            OneCheck("RESET");
            totalActorNum = 0;
            SelectedGun = "NONE";
            keyBind.Text = "";
            advanceActorBox.SelectedIndex = -1;
            advanceActorBox.IsEnabled = false;
            enableBoneCheck.IsChecked = false;
            ComboActorNum.Items.Clear();
            xPos.IsEnabled = false;
            yPos.IsEnabled = false;
            zPos.IsEnabled = false;
            deathAnimBox.Items.Clear();
            idleAnimBox.Items.Clear();
            spAnimBox.Items.Clear();
            headBox.Items.Clear();
            bodyBox.Items.Clear();
            spBox.Items.Clear();
            demoRecording.IsEnabled = false;
            sunControllerTab.IsEnabled = false;
            cfgTextBox.Text = "";
            sunCheckBox.IsEnabled = false;
            singleSendBox.Text = "";
            selectedBody.Text = "";
            mapBox.Text = "";
            otherTab.IsEnabled = false;
            ComboWeaponBone.Text = "j_gun";
            currentIdleAnimBox.Text = "";
            currentDeathAnimBox.Text = "";
            Econsole.Send("mvm_actor_gopro off");
            System.Threading.Thread.Sleep(50);
            Econsole.Send("mvm_actor_gopro delete");
            createActorBtn.IsEnabled = false;
            teleportActorBtn.IsEnabled = false;
            deleteActorBtn.IsEnabled = false;
            backActorBtn.IsEnabled = false;
            ComboActorNum.IsEnabled = false;
            sendAllActorBtn.IsEnabled = false;
            sendAnimsBtn.IsEnabled = false;
            sendWeaponsBtn.IsEnabled = false;
            removeWeaponsBtn.IsEnabled = false;
            sendModelsBtn.IsEnabled = false;
            autosendCheck.IsEnabled = false;
            autosendCheck.IsChecked = false;
            modelsItem.IsEnabled = false;
            animsItem.IsEnabled = false;
            miscItem.IsEnabled = false;
            bindsItem.IsEnabled = false;
            weaponsItem.IsEnabled = false;
            if (mainTabs.SelectedIndex != 5)
            {
                mainTabs.SelectedIndex = 0;
            }
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
        // https://www.flaticon.com/free-icon/gun_556206
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
            OneCheck("AT4");
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
                case "RESET":
                    {
                        SelectedGun = "";

                        foreach (System.Windows.Controls.CheckBox guncheck in gunChecks)
                        {
                            guncheck.IsChecked = false;
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
        private void removeWeaponsBtn_Click(object sender, RoutedEventArgs e)
        {
            Econsole.Send($"mvm_actor_weapon {ComboActorNum.Text} {ComboWeaponBone.Text}");
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
                Econsole.Send("actorback");
            }
            else
            {
                ModernWpf.MessageBox.Show("Please Select An Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backActorBtn_Click(object sender, RoutedEventArgs e)
        {
            Econsole.Send("actorback");
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
            if (precacheBox.Text != "No Precache Selected" && MessageBox.Show("This will reset the console and your selected precache. OK?", "Info", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                precacheBox.Text = "No Precache Selected";
                precacheBtn.Visibility = Visibility.Visible;
                Reset();
                if (File.Exists("settings.ini"))
                {
                    File.Delete("settings.ini");
                }
            }
        }
        private void ComboActorNum_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            OneCheck("RESET");
            ComboWeaponBone.SelectedIndex = 0;
            currentDeathAnimBox.Text = "";
            currentIdleAnimBox.Text = "";
            selectedHead.Text = "";
            selectedBody.Text = "";
        }
        #endregion
        #region Anims Tab
        // https://www.flaticon.com/premium-icon/anchor-point_5340627
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
            try
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
                idleAnimBox.SelectedIndex = -1;
            }
            catch
            {

            }
        }

        private void deathAnimBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
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
                deathAnimBox.SelectedIndex = -1;
            }
            catch
            {

            }

        }

        private void spAnimBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
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
                spAnimBox.SelectedIndex = -1;
            }
            catch
            {

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
            System.Threading.Thread.Sleep(100);
            Econsole.Send($"mvm_actor_death {ComboActorNum.Text} {currentDeathAnimBox.Text}");
        }
        #endregion
        #region Models Tab
        //https://www.flaticon.com/free-icon/3d-modeling_3208383
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
                string x = Classes.MemoryFuncs.GetCurrentMap();
                if (x != "Could Not Find Current Map")
                {
                    mapBox.Text = x;
                }
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
            try
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
                bodyBox.SelectedIndex = -1;
            }
            catch
            {

            }
        }

        private void headBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
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
                headBox.SelectedIndex = -1;
            }
            catch
            {

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
            try
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
                spBox.SelectedIndex = -1;
            }
            catch
            {

            }
        }


        #endregion
        #region Pathing Tab
        // https://www.flaticon.com/free-icon/walk_7458163
        private void addBindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (directionBindBox.Text == "" || actorNumBindBox.Text == "" || keyBind.Text == "" || speedBind.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(keyBind.Text, "^[a-zA-Z0-9]"))
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

                foreach (string j in Classes.StringFuncs.RemoveLastElement<string>(i.ToString().Split(',')))
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
            keyBind.Text = "";
            actorNumBindBox.Text = "";
            speedBind.Text = "7";
            directionBindBox.Text = "forward";
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

            // get better way to remove bind that doenst remove number.
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
        // https://www.flaticon.com/free-icon/terminals_6996035
        private void miscItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void sendCfgBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (string line in cfgTextBox.Text.Split('\n'))
            {
                if (line.Trim().Contains("//") || line.Trim().Contains("mvm_actor_spawn"))
                {
                    Console.WriteLine("invalid line");
                    // find way to run on different thread without errors
                }
                else
                {
                    Econsole.Send(line.Trim());
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

        private void sendSingleBtn_Click(object sender, RoutedEventArgs e)
        {
            Econsole.Send(singleSendBox.Text);
        }

        private void demosTab_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                demosListBox.Items.Clear();
                //string[] playersFiles = Directory.GetFiles(Directory.GetParent(Directory.GetParent(Directory.GetParent(precacheBox.Text).FullName).FullName).FullName + "\\players\\");
                string[] demos = Directory.GetFiles(Directory.GetParent(precacheBox.Text) + "\\demos");


                foreach (string f in demos)
                {
                    if (!f.Contains(".json") && !f.Contains(".meta"))
                    {
                        demosListBox.Items.Add(Path.GetFileNameWithoutExtension(f));
                    }
                }
            }
            catch
            {
                demosListBox.Items.Add("Could Not Find Demos");
            }
        }
        private void loadDemoBtn_Click(object sender, RoutedEventArgs e)
        {
            Econsole.Send("r_aasamples 1");
            Econsole.Send($"demo {selectedDemoBox.Text}");
        }

        private void demosListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ("Could Not Find Demos" == (string)demosListBox.SelectedItem)
            {

            }
            else
            {
                selectedDemoBox.Text = (string)demosListBox.SelectedItem;
            }
            demosListBox.SelectedIndex = -1;
        }

        private void demoRecording_Click(object sender, RoutedEventArgs e)
        {
            if (demoRecording.Content.ToString().Contains("Stop"))
            {
                Econsole.Send("stoprecord");
                demoRecording.ClearValue(Button.BackgroundProperty);
                demoRecording.Content = "Start Recording";
            }
            else
            {
                demoNameDialog.ShowAsync();
            }
        }
        private void demoNameDialog_PrimaryButtonClick(ModernWpf.Controls.ContentDialog sender, ModernWpf.Controls.ContentDialogButtonClickEventArgs args)
        {
            try
            {
                string[] demos = Directory.GetFiles(Directory.GetParent(precacheBox.Text) + "\\demos");
                foreach (string f in demos)
                {
                    if (demoNameBox.Text.Trim().Replace(" ", "_") == Path.GetFileNameWithoutExtension(f))
                    {
                        demoRecording.Content = "Start Recording";
                        ModernWpf.MessageBox.Show("Demo Name Already Exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                demoRecording.Background = Brushes.DarkRed;
                demoRecording.Content = "Stop Recording";

                Econsole.Send("stoprecord");
                System.Threading.Thread.Sleep(50);
                Econsole.Send($"record {demoNameBox.Text.Trim().Replace(" ", "_")}");
            }
            catch
            {
                ModernWpf.MessageBox.Show("Could Not Start Recording", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void demoNameDialog_CloseButtonClick(ModernWpf.Controls.ContentDialog sender, ModernWpf.Controls.ContentDialogButtonClickEventArgs args)
        {

        }

        #endregion
        #region Artificial Actor Menu
        private void CreateMenu()
        {
            FakeActorView m = new FakeActorView();
            m.Show();

        }
        private void artActorMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateMenu();
        }







        #endregion
        #region Advanced Pathing
        private void advancePathTab_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            advanceActorBox.ItemsSource = ComboActorNum.Items;
            DisableAActorBox();
        }
        private void DisableAActorBox()
        {
            advanceActorBox.ItemsSource = ComboActorNum.Items;
            if (pointBox.Items.Count > 0)
            {
                advanceActorBox.IsEnabled = false;
            }
            else
            {
                advanceActorBox.IsEnabled = true;
            }
            if (advanceActorBox.SelectedIndex == -1)
            {
                pointBox.Items.Clear();
                addPointBtn.IsEnabled = false;
                removePointBtn.IsEnabled = false;
                playPathbtn.IsEnabled = false;
                speedBoxA.IsEnabled = false;
                pointBox.IsEnabled = false;
            }
            else
            {
                addPointBtn.IsEnabled = true;
                removePointBtn.IsEnabled = true;
                playPathbtn.IsEnabled = true;
                speedBoxA.IsEnabled = true;
                pointBox.IsEnabled = true;
            }
        }
        private void addPointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pointBox.Items.Count >= 13)
            {
                ModernWpf.MessageBox.Show("Cannot add more than 13 points", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            pointBox.Items.Add($"{advanceActorBox.Text}, {pointBox.Items.Count + 1}");
            Econsole.Send($"mvm_actor_path_save {advanceActorBox.Text} {pointBox.Items.Count}");
        }

        private void removePointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pointBox.Items.Count == 0)
            {
                ModernWpf.MessageBox.Show("Please Add Points", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                RemoveAdvancePoint(pointBox.SelectedIndex);
                pointBox.SelectedIndex = -1;
            }
            catch
            {

            }
        }
        private void RemoveAdvancePoint(int at)
        {
            do
            {
                Econsole.Send($"mvm_actor_path_del {advanceActorBox.Text} {pointBox.Items.Count}");
                pointBox.Items.Remove(pointBox.Items.GetItemAt(pointBox.Items.Count - 1));
            } while (pointBox.Items.Count > at);
        }

        private void playPathbtn_Click(object sender, RoutedEventArgs e)
        {
            if (pointBox.Items.Count == 0)
            {
                ModernWpf.MessageBox.Show("Please Add Points", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Econsole.Send($"mvm_actor_path_walk {advanceActorBox.Text} {speedBoxA.Text}");
        }
        #endregion
        #region other
        // https://www.flaticon.com/free-icon/more_6511674

        private void enableBoneCheck_Click(object sender, RoutedEventArgs e)
        {
            if (ComboActorNum.Text == "")
            {
                ModernWpf.MessageBox.Show("Please Have An Actor Selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                enableBoneCheck.IsChecked = false;
                return;
            }
            if (!(bool)enableBoneCheck.IsChecked)
            {
                selectBoneBox.IsEnabled = false;
                position1.IsEnabled = false;
                position2.IsEnabled = false;
                position3.IsEnabled = false;
                rotation1.IsEnabled = false;
                rotation2.IsEnabled = false;
                rotation3.IsEnabled = false;
                fovSlider.IsEnabled = false;
                Econsole.Send("mvm_actor_gopro off");
                System.Threading.Thread.Sleep(50);
                Econsole.Send("mvm_actor_gopro delete");
                System.Threading.Thread.Sleep(50);
                Econsole.Send("mvm_actor_gopro off");
            }
            else
            {
                selectBoneBox.IsEnabled = true;
                position1.IsEnabled = true;
                position2.IsEnabled = true;
                position3.IsEnabled = true;
                rotation1.IsEnabled = true;
                rotation2.IsEnabled = true;
                fovSlider.IsEnabled = true;
                rotation3.IsEnabled = true;
                UpdateBoneCam();
                System.Threading.Thread.Sleep(100);
                Econsole.Send("mvm_actor_gopro on");
            }
        }

        private void UpdateBoneCam()
        {
            Econsole.Send($"mvm_actor_gopro {ComboActorNum.Text} {selectBoneBox.Text} {position1.Value} {position2.Value} {position3.Value} {rotation1.Value} {rotation2.Value} {rotation3.Value}");
            System.Threading.Thread.Sleep(50);
            Econsole.Send($"cg_fovScale {fovSlider.Value}");
            System.Threading.Thread.Sleep(50);
            position1Text.Text = Math.Floor(position1.Value).ToString();
            position2Text.Text = Math.Floor(position2.Value).ToString();
            position3Text.Text = Math.Floor(position3.Value).ToString();
            rotation1Text.Text = Math.Floor(rotation1.Value).ToString();
            rotation2Text.Text = Math.Floor(rotation2.Value).ToString();
            rotation3Text.Text = Math.Floor(rotation3.Value).ToString();
            Econsole.Send("mvm_actor_gopro on");

        }

        private void position1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBoneCam();
        }

        private void position2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBoneCam();
        }

        private void position3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBoneCam();
        }

        private void rotation1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBoneCam();
        }

        private void rotation2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBoneCam();
        }

        private void rotation3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateBoneCam();
        }

        private void fovSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //UpdateBoneCam();
        }

        private void selectBoneBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //UpdateBoneCam();
        }
        private void presetListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (presetListBox.SelectedIndex)
            {
                case 0:
                    {
                        selectBoneBox.SelectedIndex = 1;
                        position1.Value = -10;
                        position2.Value = 30;
                        position3.Value = 130;
                        rotation1.Value = 100;
                        rotation2.Value = 95;
                        rotation3.Value = 120;
                        fovSlider.Value = 0.4;
                        UpdateBoneCam();
                        break;
                    }
                case 1:
                    {
                        selectBoneBox.SelectedIndex = 1;
                        position1.Value = 86;
                        position2.Value = 108;
                        position3.Value = 0;
                        rotation1.Value = 180;
                        rotation2.Value = 51;
                        rotation3.Value = 97;
                        fovSlider.Value = 0.1;
                        UpdateBoneCam();
                        break;
                    }
                case 2:
                    {
                        selectBoneBox.SelectedIndex = 0;
                        position1.Value = 114;
                        position2.Value = 50;
                        position3.Value = 0;
                        rotation1.Value = 180;
                        rotation2.Value = 20;
                        rotation3.Value = 174;
                        fovSlider.Value = 0.1;
                        UpdateBoneCam();
                        break;
                    }
                case 3:
                    {
                        selectBoneBox.SelectedIndex = 0;
                        position1.Value = 132;
                        position2.Value = 0;
                        position3.Value = -2;
                        rotation1.Value = 180;
                        rotation2.Value = 0;
                        rotation3.Value = 180;
                        fovSlider.Value = 0.1;
                        UpdateBoneCam();
                        break;
                    }
                case 4:
                    {
                        selectBoneBox.SelectedIndex = 1;
                        position1.Value = 132;
                        position2.Value = 0;
                        position3.Value = -2;
                        rotation1.Value = 180;
                        rotation2.Value = 0;
                        rotation3.Value = 180;
                        fovSlider.Value = 0.1;
                        UpdateBoneCam();
                        break;
                    }
                case 5:
                    {
                        selectBoneBox.SelectedIndex = 1;
                        position1.Value = -41;
                        position2.Value = -112;
                        position3.Value = -2;
                        rotation1.Value = 180;
                        rotation2.Value = -112;
                        rotation3.Value = -99;
                        fovSlider.Value = 0.1;
                        UpdateBoneCam();
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }



        private byte defaultR = 0x0;
        private byte defaultG = 0x0;
        private byte defaultB = 0x0;
        private float defaultX = 0x0;
        private float defaultY = 0x0;
        private float defaultZ = 0x0;
        private void sunCheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EnableSunToggle();
            }
            catch
            {

            }
        }
        public void EnableSunToggle()
        {
            float[] currentSun = Classes.MemoryFuncs.GetCurrentSunSettings();
            if ((bool)sunCheckBox.IsChecked)
            {
                sunColor.IsEnabled = true;
                xPos.IsEnabled = true;
                yPos.IsEnabled = true;
                zPos.IsEnabled = true;
                savePresetSun.IsEnabled = true;
                loadPresetSun.IsEnabled = true;
                defaultR = (byte)(currentSun[0] * 127.5);
                defaultG = (byte)(currentSun[1] * 127.5);
                defaultB = (byte)(currentSun[2] * 127.5);
                defaultX = currentSun[3];
                defaultY = currentSun[4];
                defaultZ = currentSun[5];
                sunColor.R = defaultR;
                sunColor.G = defaultG;
                sunColor.B = defaultB;
                xPos.Value = defaultX;
                yPos.Value = defaultY;
                zPos.Value = defaultZ;

            }
            else
            {
                sunColor.R = defaultR;
                sunColor.G = defaultG;
                sunColor.B = defaultB;
                xPos.Value = defaultX;
                yPos.Value = defaultY;
                zPos.Value = defaultZ;
                Classes.MemoryFuncs.WriteSunColor((float)(sunColor.R / 127.5), (float)(sunColor.G / 127.5), (float)(sunColor.B / 127.5));
                Classes.MemoryFuncs.WriteSunPosition((float)xPos.Value, (float)yPos.Value, (float)zPos.Value);
                sunColor.IsEnabled = false;
                xPos.IsEnabled = false;
                yPos.IsEnabled = false;
                zPos.IsEnabled = false;
                savePresetSun.IsEnabled = false;
                loadPresetSun.IsEnabled = false;
            }
        }

        private void sunColor_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Classes.MemoryFuncs.WriteSunColor((float)(sunColor.R / 127.5), (float)(sunColor.G / 127.5), (float)(sunColor.B / 127.5));
        }

        private void loadPresetSun_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sun Files (*.sun)|*.sun";
            if (openFileDialog.ShowDialog() == true)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                sunColor.R = byte.Parse(lines[0]);
                sunColor.G = byte.Parse(lines[1]);
                sunColor.B = byte.Parse(lines[2]);
                xPos.Value = float.Parse(lines[3]);
                yPos.Value = float.Parse(lines[4]);
                zPos.Value = float.Parse(lines[5]);
                Classes.MemoryFuncs.WriteSunColor((float)(sunColor.R / 127.5), (float)(sunColor.G / 127.5), (float)(sunColor.B / 127.5));
                Classes.MemoryFuncs.WriteSunPosition((float)xPos.Value, (float)yPos.Value, (float)zPos.Value);

            }
        }

        private void savePresetSun_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sun Files (*.sun)|*.sun";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, $"{sunColor.R}\n{sunColor.G}\n{sunColor.B}\n{xPos.Value}\n{yPos.Value}\n{zPos.Value}");

            }
        }

        private void zPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Classes.MemoryFuncs.WriteSunPosition((float)xPos.Value, (float)yPos.Value, (float)zPos.Value);
            zPosText.Text = Math.Round(zPos.Value, 4).ToString();
        }

        private void yPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Classes.MemoryFuncs.WriteSunPosition((float)xPos.Value, (float)yPos.Value, (float)zPos.Value);
            yPosText.Text = Math.Round(yPos.Value, 4).ToString();
        }

        private void xPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Classes.MemoryFuncs.WriteSunPosition((float)xPos.Value, (float)yPos.Value, (float)zPos.Value);
            xPosText.Text = Math.Round(xPos.Value, 4).ToString();
        }
        #endregion
        #region Dvar Animation

        private void startAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDvarAnim.Text.Trim() == "")
            {
                ModernWpf.MessageBox.Show("Please Enter A Dvar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Classes.DvarAnimation.isRunning)
            {
                Classes.DvarAnimation.StartAnimation(selectedDvarAnim.Text.Trim(), fromAnimBtn.Value, toAnimBtn.Value, speedAnimBtn.Value);
                startAnimationBtn.Content = "Stop Animation";
                dvarAnimSlider.IsEnabled = false;
            }
            else
            {
                Classes.DvarAnimation.StopAnimation();
                startAnimationBtn.Content = "Start Animation";
                dvarAnimSlider.IsEnabled = true;
            }
        }

        private void dvarAnimSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (selectedDvarAnim.Text.Trim() == "")
            {
                ModernWpf.MessageBox.Show("Please Enter A Dvar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            dvarAnimSlider.Minimum = fromAnimBtn.Value;
            dvarAnimSlider.Maximum = toAnimBtn.Value;
            Econsole.Send($"{selectedDvarAnim.Text.Trim()} {dvarAnimSlider.Value}");
        }

        private void dvarAnimSlider_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            dvarAnimSlider.Minimum = fromAnimBtn.Value;
            dvarAnimSlider.Maximum = toAnimBtn.Value;
        }


        #endregion
    }
}
