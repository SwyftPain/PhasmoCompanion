using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Pipes;
using System.Windows.Interop;

namespace PhasmoCompanion
{
    public static class SendKeys
    {
        /// <summary>
        ///   Sends the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Enter) { RoutedEvent = Keyboard.KeyDownEvent };
                    InputManager.Current.ProcessInput(e1);
                }
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
public partial class MainWindow : Window
    {
        string evidenceonee = "";
        string evidencetwoo = "";
        string evidencethreee = "";
        string showem = "";
        public MainWindow()
        {
            // declare arguments
            string[] args = Environment.GetCommandLineArgs();
            Dictionary<string, string> arguments = new Dictionary<string, string>();

            for (int index = 1; index < args.Length; index += 2)
            {
                string arg = args[index].Replace("--", "");
                arguments.Add(arg, args[index + 1]);
            }
            // Do not allow duplicate launch
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                Application.Current.Shutdown();
            }
            // initial values
            InitializeComponent();
            // start with
            weaklabel.Visibility = Visibility.Hidden;
            stronglabel.Visibility = Visibility.Hidden;
            bgweak.Visibility = Visibility.Hidden;
            bgstrong.Visibility = Visibility.Hidden;
            weakness.Content = "";
            strength.Content = "";
            // check arguments
            if (arguments.ContainsKey("third"))
            {
                // third argument
                if (arguments["third"].Equals("Freezing Temps.", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 0;
                }
                else if (arguments["third"].Equals("Fingerprints", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 1;
                }
                else if (arguments["third"].Equals("Ghostwriting", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 2;
                }
                else if (arguments["third"].Equals("Ghost Orb", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 3;
                }
                else if (arguments["third"].Equals("Spiritbox", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 4;
                }
                else if (arguments["third"].Equals("D.O.T.S. Projector", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 5;
                }
                else if (arguments["third"].Equals("EMF Level 5", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 6;
                }
                else if (arguments["third"].Equals("None", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencethree.SelectedIndex = 7;
                }
                else
                {
                    evidencethree.SelectedIndex = 7;
                }
            }
            if (arguments.ContainsKey("second"))
            {
                // second argument
                if (arguments["second"].Equals("Freezing Temps.", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 0;
                }
                else if (arguments["second"].Equals("Fingerprints", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 1;
                }
                else if (arguments["second"].Equals("Ghostwriting", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 2;
                }
                else if (arguments["second"].Equals("Ghost Orb", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 3;
                }
                else if (arguments["second"].Equals("Spiritbox", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 4;
                }
                else if (arguments["second"].Equals("D.O.T.S. Projector", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 5;
                }
                else if (arguments["second"].Equals("EMF Level 5", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 6;
                }
                else if (arguments["second"].Equals("None", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidencetwo.SelectedIndex = 7;
                }
                else
                {
                    evidencetwo.SelectedIndex = 7;
                }
            }
            if (arguments.ContainsKey("first"))
            {
                // first argument
                if (arguments["first"].Equals("Freezing Temps.", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 0;
                }
                else if (arguments["first"].Equals("Fingerprints", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 1;
                }
                else if (arguments["first"].Equals("Ghostwriting", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 2;
                }
                else if (arguments["first"].Equals("Ghost Orb", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 3;
                }
                else if (arguments["first"].Equals("Spiritbox", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 4;
                }
                else if (arguments["first"].Equals("D.O.T.S. Projector", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 5;
                }
                else if (arguments["first"].Equals("EMF Level 5", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 6;
                }
                else if (arguments["first"].Equals("None", StringComparison.CurrentCultureIgnoreCase))
                {
                    evidenceone.SelectedIndex = 7;
                }
                else
                {
                    evidenceone.SelectedIndex = 7;
                }
            }
            checkghost.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        string[] demon = { "Freezing Temps.", "Fingerprints", "Ghostwriting" };
        string[] hantu = { "Freezing Temps.", "Fingerprints", "Ghost Orb" };
        string[] jinn = { "Freezing Temps.", "Fingerprints", "EMF Level 5" };
        string[] oni = { "Freezing Temps.", "EMF Level 5", "D.O.T.S. Projector" };
        string[] onryo = { "Freezing Temps.", "Spiritbox", "Ghost Orb" };
        string[] revenant = { "Freezing Temps.", "Ghostwriting", "Ghost Orb" };
        string[] shade = { "Freezing Temps.", "Ghostwriting", "EMF Level 5" };
        string[] themimic = { "Freezing Temps.", "Fingerprints", "Spiritbox" };
        string[] thetwins = { "Freezing Temps.", "EMF Level 5", "Spiritbox" };
        string[] yurei = { "Freezing Temps.", "D.O.T.S. Projector", "Ghost Orb" };
        string[] mare = { "Spiritbox", "Ghostwriting", "Ghost Orb" };
        string[] phantom = { "Spiritbox", "Fingerprints", "D.O.T.S. Projector" };
        string[] poltergeist = { "Spiritbox", "Fingerprints", "Ghostwriting" };
        string[] spirit = { "Spiritbox", "EMF Level 5", "Ghostwriting" };
        string[] wraith = { "Spiritbox", "EMF Level 5", "D.O.T.S. Projector" };
        string[] yokai = { "Spiritbox", "Ghost Orb", "D.O.T.S. Projector" };
        string[] banshee = { "Fingerprints", "Ghost Orb", "D.O.T.S. Projector" };
        string[] goryo = { "Fingerprints", "EMF Level 5", "D.O.T.S. Projector" };
        string[] myling = { "Fingerprints", "EMF Level 5", "Ghostwriting" };
        string[] obake = { "Fingerprints", "EMF Level 5", "Ghost Orb" };
        string[] raiju = { "D.O.T.S. Projector", "EMF Level 5", "Ghost Orb" };
        string[] fringe = { "Freezing Temps.", "Fingerprints" };
        string[] fremf = { "Freezing Temps.", "EMF Level 5" };
        string[] frots = { "Freezing Temps.", "D.O.T.S. Projector" };
        string[] frorb = { "Freezing Temps.", "Ghost Orb" };
        string[] friting = { "Freezing Temps.", "Ghostwriting" };
        string[] frox = { "Freezing Temps.", "Spiritbox" };
        string[] finots = { "Fingerprints", "D.O.T.S. Projector" };
        string[] finemf = { "Fingerprints", "EMF Level 5" };
        string[] finorb = { "Fingerprints", "Ghost Orb" };
        string[] finiting = { "Fingerprints", "Ghostwriting" };
        string[] finox = { "Fingerprints", "Spiritbox" };
        string[] emots = { "EMF Level 5", "D.O.T.S. Projector" };
        string[] emorb = { "EMF Level 5", "Ghost Orb" };
        string[] emiting = { "EMF Level 5", "Ghostwriting" };
        string[] emox = { "EMF Level 5", "Spiritbox" };
        string[] dotorb = { "Ghost Orb", "D.O.T.S. Projector" };
        string[] doting = { "Ghostwriting", "D.O.T.S. Projector" };
        string[] dotox = { "Spiritbox", "D.O.T.S. Projector" };
        string[] orbing = { "Ghost Orb", "Ghostwriting" };
        string[] orbox = { "Ghost Orb", "Spiritbox" };
        string[] wrox = { "Ghostwriting", "Spiritbox" };
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void evidenceone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (evidenceone.SelectedIndex)
            {
                case 0:
                    if (evidenceone.SelectedIndex == 0)
                    {
                        evidenceonee = "Freezing Temps.";
                    }
                    break;
                case 1:
                    if (evidenceone.SelectedIndex == 1)
                    {
                        evidenceonee = "Fingerprints";
                    }
                    break;
                case 2:
                    if (evidenceone.SelectedIndex == 2)
                    {
                        evidenceonee = "Ghostwriting";
                    }
                    break;
                case 3:
                    if (evidenceone.SelectedIndex == 3)
                    {
                        evidenceonee = "Ghost Orb";
                    }
                    break;
                case 4:
                    if (evidenceone.SelectedIndex == 4)
                    {
                        evidenceonee = "Spiritbox";
                    }
                    break;
                case 5:
                    if (evidenceone.SelectedIndex == 5)
                    {
                        evidenceonee = "D.O.T.S. Projector";
                    }
                    break;
                case 6:
                    if (evidenceone.SelectedIndex == 6)
                    {
                        evidenceonee = "EMF Level 5";
                    }
                    break;
                case 7:
                    if (evidenceone.SelectedIndex == 7)
                    {
                        evidenceonee = "None";
                    }
                    break;
            }
        }

        private void evidence2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (evidencetwo.SelectedIndex)
            {
                case 0:
                    if (evidencetwo.SelectedIndex == 0)
                    {
                        evidencetwoo = "Freezing Temps.";
                    }
                    break;
                case 1:
                    if (evidencetwo.SelectedIndex == 1)
                    {
                        evidencetwoo = "Fingerprints";
                    }
                    break;
                case 2:
                    if (evidencetwo.SelectedIndex == 2)
                    {
                        evidencetwoo = "Ghostwriting";
                    }
                    break;
                case 3:
                    if (evidencetwo.SelectedIndex == 3)
                    {
                        evidencetwoo = "Ghost Orb";
                    }
                    break;
                case 4:
                    if (evidencetwo.SelectedIndex == 4)
                    {
                        evidencetwoo = "Spiritbox";
                    }
                    break;
                case 5:
                    if (evidencetwo.SelectedIndex == 5)
                    {
                        evidencetwoo = "D.O.T.S. Projector";
                    }
                    break;
                case 6:
                    if (evidencetwo.SelectedIndex == 6)
                    {
                        evidencetwoo = "EMF Level 5";
                    }
                    break;
                case 7:
                    if (evidencetwo.SelectedIndex == 7)
                    {
                        evidencetwoo = "None";
                    }
                    break;
            }
        }

        private void evidencethree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (evidencethree.SelectedIndex)
            {
                case 0:
                    if (evidencethree.SelectedIndex == 0)
                    {
                        evidencethreee = "Freezing Temps.";
                    }
                    break;
                case 1:
                    if (evidencethree.SelectedIndex == 1)
                    {
                        evidencethreee = "Fingerprints";
                    }
                    break;
                case 2:
                    if (evidencethree.SelectedIndex == 2)
                    {
                        evidencethreee = "Ghostwriting";
                    }
                    break;
                case 3:
                    if (evidencethree.SelectedIndex == 3)
                    {
                        evidencethreee = "Ghost Orb";
                    }
                    break;
                case 4:
                    if (evidencethree.SelectedIndex == 4)
                    {
                        evidencethreee = "Spiritbox";
                    }
                    break;
                case 5:
                    if (evidencethree.SelectedIndex == 5)
                    {
                        evidencethreee = "D.O.T.S. Projector";
                    }
                    break;
                case 6:
                    if (evidencethree.SelectedIndex == 6)
                    {
                        evidencethreee = "EMF Level 5";
                    }
                    break;
                case 7:
                    if (evidencethree.SelectedIndex == 7)
                    {
                        evidencethreee = "None";
                    }
                    break;
            }
        }

        private void checkghost_Click(object sender, RoutedEventArgs e)
        {
            string[] evidenceslist = { evidenceonee, evidencetwoo, evidencethreee };
            // single evidence
            if ((evidenceonee == evidencetwoo) || (evidencethreee == evidenceonee) || (evidencetwoo == evidencethreee))
            {
                ghostname.Content = "None";
                singular.Content = "Possible ghost:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (evidenceonee == "None" && evidencetwoo == "None")
            {
                ghostname.Content = "Need more info.";
                singular.Content = "Possible ghost:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (evidenceonee == "None" && evidencethreee == "None")
            {
                ghostname.Content = "Need more info.";
                singular.Content = "Possible ghost:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (evidencetwoo == "None" && evidencethreee == "None")
            {
                ghostname.Content = "Need more info.";
                singular.Content = "Possible ghost:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (evidenceonee == "None" && evidencetwoo == "None" && evidencethreee == "None")
            {
                ghostname.Content = "Need more info.";
                singular.Content = "Possible ghost:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // triple evidences
            else if (demon.Contains(evidenceonee) && demon.Contains(evidencetwoo) && demon.Contains(evidencethreee))
            {
                ghostname.Content = "Demon";
                singular.Content = "Ghost found:";
                strength.Content = "Demons will initiate hunts more often than other ghosts.";
                weakness.Content = "Demons fear the Crucifix and will be less aggressive near\r\none.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (hantu.Contains(evidenceonee) && hantu.Contains(evidencetwoo) && hantu.Contains(evidencethreee))
            {
                ghostname.Content = "Hantu";
                singular.Content = "Ghost found:";
                strength.Content = "Lower temperatures allow the Hantu to move at\r\nfaster speeds.";
                weakness.Content = "Hantu moves slower in warmer areas.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (jinn.Contains(evidenceonee) && jinn.Contains(evidencetwoo) && jinn.Contains(evidencethreee))
            {
                ghostname.Content = "Jinn";
                singular.Content = "Ghost found:";
                strength.Content = "A Jinn will travel at a faster speed if its victim is far away.";
                weakness.Content = "Turning off the location's power source will\r\nprevent the Jinn from\r\nusing its ability.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (oni.Contains(evidenceonee) && oni.Contains(evidencetwoo) && oni.Contains(evidencethreee))
            {
                ghostname.Content = "Oni";
                singular.Content = "Ghost found:";
                strength.Content = "Onis are more active when people are nearby\r\nand have been seen moving\r\nobjects at great speed.";
                weakness.Content = "Onis are very active, making them easier to\r\nfind.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (onryo.Contains(evidenceonee) && onryo.Contains(evidencetwoo) && onryo.Contains(evidencethreee))
            {
                ghostname.Content = "Onryo";
                singular.Content = "Ghost found:";
                strength.Content = "Extinguishing a flame can cause an Onryo to\r\nattack.";
                weakness.Content = "When threatened, this ghost will be less\r\nlikely to hunt.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (revenant.Contains(evidenceonee) && revenant.Contains(evidencetwoo) && revenant.Contains(evidencethreee))
            {
                ghostname.Content = "Revenant";
                singular.Content = "Ghost found:";
                strength.Content = "A Revenant will travel at a significantly\r\nfaster speed when hunting\r\ntheir prey.";
                weakness.Content = "Hiding from the Revenant will cause it to\r\nmove very slowly.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (shade.Contains(evidenceonee) && shade.Contains(evidencetwoo) && shade.Contains(evidencethreee))
            {
                ghostname.Content = "Shade";
                singular.Content = "Ghost found:";
                strength.Content = "Shades are much harder to find.";
                weakness.Content = "The ghost will not enter a hunt if there\r\nare multiple people nearby.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (themimic.Contains(evidenceonee) && themimic.Contains(evidencetwoo) && themimic.Contains(evidencethreee))
            {
                ghostname.Content = "The Mimic";
                singular.Content = "Ghost found:";
                strength.Content = "We're unsure what this ghost is capable\r\nof. Be careful.";
                weakness.Content = "Several reports have noted ghost orb\r\nsightings near mimics.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (thetwins.Contains(evidenceonee) && thetwins.Contains(evidencetwoo) && thetwins.Contains(evidencethreee))
            {
                ghostname.Content = "The Twins";
                singular.Content = "Ghost found:";
                strength.Content = "Either Twin can be angered and\r\ninitiate an attack on\r\ntheir prey.";
                weakness.Content = "The Twins will often interact\r\nwith the environment at\r\nthe same time.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (yurei.Contains(evidenceonee) && yurei.Contains(evidencetwoo) && yurei.Contains(evidencethreee))
            {
                ghostname.Content = "Yurei";
                singular.Content = "Ghost found:";
                strength.Content = "Yureis have been known to have\r\na stronger effect on\r\npeople's sanity.";
                weakness.Content = "Smudging the Yurei's place of\r\ndeath will trap it temporarily,\r\nreducing how much it wanders.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (mare.Contains(evidenceonee) && mare.Contains(evidencetwoo) && mare.Contains(evidencethreee))
            {
                ghostname.Content = "Mare";
                singular.Content = "Ghost found:";
                strength.Content = "A Mare will have an increased\r\nchance to attack in the\r\ndark.";
                weakness.Content = "Turning the lights on around\r\nthe Mare will lower its\r\nchance to attack.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (phantom.Contains(evidenceonee) && phantom.Contains(evidencetwoo) && phantom.Contains(evidencethreee))
            {
                ghostname.Content = "Phantom";
                singular.Content = "Ghost found:";
                strength.Content = "Looking at a Phantom will drop\r\nyour sanity considerably\r\nfaster.";
                weakness.Content = "Taking a photo of the Phantom\r\nwill make it temporarily\r\ndisappear.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (poltergeist.Contains(evidenceonee) && poltergeist.Contains(evidencetwoo) && poltergeist.Contains(evidencethreee))
            {
                ghostname.Content = "Poltergeist";
                singular.Content = "Ghost found:";
                strength.Content = "Poltergeists can throw\r\nmultiple objects at nonce.";
                weakness.Content = "With nothing to throw,\r\nPoltergeists become powerless.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (spirit.Contains(evidenceonee) && spirit.Contains(evidencetwoo) && spirit.Contains(evidencethreee))
            {
                ghostname.Content = "Spirit";
                singular.Content = "Ghost found:";
                strength.Content = "No quote was found in the\r\nJournal for their strength, since\r\nthey do not have one.";
                weakness.Content = "A Spirit can be temporarily\r\nstopped by burning Smudge Sticks\r\nnear them.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (wraith.Contains(evidenceonee) && wraith.Contains(evidencetwoo) && wraith.Contains(evidencethreee))
            {
                ghostname.Content = "Wraith";
                singular.Content = "Ghost found:";
                strength.Content = "Wraiths almost never touch\r\nthe ground, meaning it can't be\r\ntracked by footsteps.";
                weakness.Content = "Wraiths have a toxic\r\nreaction to Salt.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (yokai.Contains(evidenceonee) && yokai.Contains(evidencetwoo) && yokai.Contains(evidencethreee))
            {
                ghostname.Content = "Yokai";
                singular.Content = "Ghost found:";
                strength.Content = "Talking near a Yokai\r\nwill anger it,increasing\r\nthe chance of an attack.";
                weakness.Content = "When hunting, a Yokai\r\ncan only hear voices close\r\nto it.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (banshee.Contains(evidenceonee) && banshee.Contains(evidencetwoo) && banshee.Contains(evidencethreee))
            {
                ghostname.Content = "Banshee";
                singular.Content = "Ghost found:";
                strength.Content = "Banshee's will weaken\r\ntheir target before striking.";
                weakness.Content = "Banshee's can sometimes\r\nbe heard screaming with a\r\nparabolic microphone.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (goryo.Contains(evidenceonee) && goryo.Contains(evidencetwoo) && goryo.Contains(evidencethreee))
            {
                ghostname.Content = "Goryo";
                singular.Content = "Ghost found:";
                strength.Content = "A Goryo will usually only\r\nshow itself on camera if\r\nthere are no people nearby.";
                weakness.Content = "They are are rarely seen\r\nfar from their place of\r\ndeath.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (myling.Contains(evidenceonee) && myling.Contains(evidencetwoo) && myling.Contains(evidencethreee))
            {
                ghostname.Content = "Myling";
                singular.Content = "Ghost found:";
                strength.Content = "A Myling is known to be\r\nquieter when hunting.";
                weakness.Content = "Mylings more frequently\r\nmake paranormal sounds.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (obake.Contains(evidenceonee) && obake.Contains(evidencetwoo) && obake.Contains(evidencethreee))
            {
                ghostname.Content = "Obake";
                singular.Content = "Ghost found:";
                strength.Content = "When interacting with the\r\nenvironment, an Obake will rarely\r\nleave a trace.";
                weakness.Content = "Sometimes this ghost will\r\nshapeshift, leaving behind unique\r\nevidence.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            else if (raiju.Contains(evidenceonee) && raiju.Contains(evidencetwoo) && raiju.Contains(evidencethreee))
            {
                ghostname.Content = "Raiju";
                singular.Content = "Ghost found:";
                strength.Content = "A Raiju can siphon power\r\nfrom nearby electrical devices,\r\nmaking it move faster.";
                weakness.Content = "Raiju are constantly\r\ndisrupting electronic equipment when\r\nattacking, making it easier to track.";
                weaklabel.Visibility = Visibility.Visible;
                stronglabel.Visibility = Visibility.Visible;
                bgweak.Visibility = Visibility.Visible;
                bgstrong.Visibility = Visibility.Visible;
            }
            // double evidences
            // freezing
            else if (fringe.Contains(evidenceonee) && fringe.Contains(evidencetwoo) && evidencethreee.Equals("None") || fringe.Contains(evidenceonee) && fringe.Contains(evidencethreee) && evidencetwoo.Equals("None") || fringe.Contains(evidencethreee) && fringe.Contains(evidencetwoo) && !evidenceonee.Equals("None"))
            {
                ghostname.Content = "Mare, Raiju, Spirit, Wraith, Yokai";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (fremf.Contains(evidenceonee) && fremf.Contains(evidencetwoo) && evidencethreee.Equals("None") || fremf.Contains(evidenceonee) && fremf.Contains(evidencethreee) && evidencetwoo.Equals("None") || fremf.Contains(evidencethreee) && fremf.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Banshee, Mare, Phantom, Poltergeist, Yokai";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (frots.Contains(evidenceonee) && frots.Contains(evidencetwoo) && evidencethreee.Equals("None") || frots.Contains(evidenceonee) && frots.Contains(evidencethreee) && evidencetwoo.Equals("None") || frots.Contains(evidencethreee) && frots.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Mare, Myling, Obake, Poltergeist, Spirit";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (frorb.Contains(evidenceonee) && frorb.Contains(evidencetwoo) && evidencethreee.Equals("None") || frorb.Contains(evidenceonee) && frorb.Contains(evidencethreee) && evidencetwoo.Equals("None") || frorb.Contains(evidencethreee) && frorb.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Goryo, Myling, Phantom, Poltergeist, Spirit, Wraith";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (friting.Contains(evidenceonee) && friting.Contains(evidencetwoo) && evidencethreee.Equals("None") || friting.Contains(evidenceonee) && friting.Contains(evidencethreee) && evidencetwoo.Equals("None") || friting.Contains(evidencethreee) && friting.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Banshee, Goryo, Obake, Phantom, Raiju, Wraith, Yokai";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (frox.Contains(evidenceonee) && frox.Contains(evidencetwoo) && evidencethreee.Equals("None") || frox.Contains(evidenceonee) && frox.Contains(evidencethreee) && evidencetwoo.Equals("None") || frox.Contains(evidencethreee) && frox.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Banshee, Goryo, Myling, Obake, Raiju";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // fingerprints
            else if (finots.Contains(evidenceonee) && finots.Contains(evidencetwoo) && evidencethreee.Equals("None") || finots.Contains(evidenceonee) && finots.Contains(evidencethreee) && evidencetwoo.Equals("None") || finots.Contains(evidencethreee) && finots.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Mare, Onryo, Revenant, Shade, Spirit, The Twins";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (finemf.Contains(evidenceonee) && finemf.Contains(evidencetwoo) && evidencethreee.Equals("None") || finemf.Contains(evidenceonee) && finemf.Contains(evidencethreee) && evidencetwoo.Equals("None") || finemf.Contains(evidencethreee) && finemf.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Mare, Onryo, Revenant, Yokai, Yurei";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (finorb.Contains(evidenceonee) && finorb.Contains(evidencetwoo) && evidencethreee.Equals("None") || finorb.Contains(evidenceonee) && finorb.Contains(evidencethreee) && evidencetwoo.Equals("None") || finorb.Contains(evidencethreee) && finorb.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Oni, Shade, Spirit, The Twins, Wraith";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (finiting.Contains(evidenceonee) && finiting.Contains(evidencetwoo) && evidencethreee.Equals("None") || finiting.Contains(evidenceonee) && finiting.Contains(evidencethreee) && evidencetwoo.Equals("None") || finiting.Contains(evidencethreee) && finiting.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Oni, Onryo, Raiju, The Twins, Wraith, Yokai, Yurei";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (finox.Contains(evidenceonee) && finox.Contains(evidencetwoo) && evidencethreee.Equals("None") || finox.Contains(evidenceonee) && finox.Contains(evidencethreee) && evidencetwoo.Equals("None") || finox.Contains(evidencethreee) && finox.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Oni, Raiju, Revenant, Shade, Yurei";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // EMF
            else if (emots.Contains(evidenceonee) && emots.Contains(evidencetwoo) && evidencethreee.Equals("None") || emots.Contains(evidenceonee) && emots.Contains(evidencethreee) && evidencetwoo.Equals("None") || emots.Contains(evidencethreee) && emots.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Demon, Hantu, Mare, Mimic, Onryo, Poltergeist, Revenant";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (emorb.Contains(evidenceonee) && emorb.Contains(evidencetwoo) && evidencethreee.Equals("None") || emorb.Contains(evidenceonee) && emorb.Contains(evidencethreee) && evidencetwoo.Equals("None") || emorb.Contains(evidencethreee) && emorb.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Demon, Phantom, Poltergeist";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (emiting.Contains(evidenceonee) && emiting.Contains(evidencetwoo) && evidencethreee.Equals("None") || emiting.Contains(evidenceonee) && emiting.Contains(evidencethreee) && evidencetwoo.Equals("None") || emiting.Contains(evidencethreee) && emiting.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Banshee, Hantu, Mimic, Onryo, Phantom, Yokai, Yurei";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (emox.Contains(evidenceonee) && emox.Contains(evidencetwoo) && evidencethreee.Equals("None") || emox.Contains(evidenceonee) && emox.Contains(evidencethreee) && evidencetwoo.Equals("None") || emox.Contains(evidencethreee) && emox.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Banshee, Demon, Hantu, Revenant, Yurei";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // D.O.T.S.
            else if (dotorb.Contains(evidenceonee) && dotorb.Contains(evidencetwoo) && evidencethreee.Equals("None") || dotorb.Contains(evidenceonee) && dotorb.Contains(evidencethreee) && evidencetwoo.Equals("None") || dotorb.Contains(evidencethreee) && dotorb.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Demon, Jinn, Myling, Poltergeist, Shade, Spirit, The Twins";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (doting.Contains(evidenceonee) && doting.Contains(evidencetwoo) && evidencethreee.Equals("None") || doting.Contains(evidenceonee) && doting.Contains(evidencethreee) && evidencetwoo.Equals("None") || doting.Contains(evidencethreee) && doting.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Hantu, Jinn, Mimic, Obake, Onryo, The Twins";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (dotox.Contains(evidenceonee) && dotox.Contains(evidencetwoo) && evidencethreee.Equals("None") || dotox.Contains(evidenceonee) && dotox.Contains(evidencethreee) && evidencetwoo.Equals("None") || dotox.Contains(evidencethreee) && dotox.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Demon, Hantu, Jinn, Myling, Obake, Revenant, Shade";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // Ghost Orb
            else if (orbing.Contains(evidenceonee) && orbing.Contains(evidencetwoo) && evidencethreee.Equals("None") || orbing.Contains(evidenceonee) && orbing.Contains(evidencethreee) && evidencetwoo.Equals("None") || orbing.Contains(evidencethreee) && orbing.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Goryo, Jinn, Oni, Phantom, The Twins, Wraith";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            else if (orbox.Contains(evidenceonee) && orbox.Contains(evidencetwoo) && evidencethreee.Equals("None") || orbox.Contains(evidenceonee) && orbox.Contains(evidencethreee) && evidencetwoo.Equals("None") || orbox.Contains(evidencethreee) && orbox.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Demon, Goryo, Jinn, Myling, Oni, Shade";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // Ghostwriting
            else if (wrox.Contains(evidenceonee) && wrox.Contains(evidencetwoo) && evidencethreee.Equals("None") || wrox.Contains(evidenceonee) && wrox.Contains(evidencethreee) && evidencetwoo.Equals("None") || wrox.Contains(evidencethreee) && wrox.Contains(evidencetwoo) && evidenceonee.Equals("None"))
            {
                ghostname.Content = "Banshee, Goryo, Hantu, Jinn, Obake, Oni, Raiju, Yurei";
                singular.Content = "Possible ghosts:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
            // Does not contain
            // else
            else
            {
                ghostname.Content = "None";
                singular.Content = "Possible ghost:";
                weaklabel.Visibility = Visibility.Hidden;
                stronglabel.Visibility = Visibility.Hidden;
                bgweak.Visibility = Visibility.Hidden;
                bgstrong.Visibility = Visibility.Hidden;
                weakness.Content = "";
                strength.Content = "";
            }
        }

        private void resetvalues_Click(object sender, RoutedEventArgs e)
        {
            ghostname.Content = "None";
            singular.Content = "Possible ghost:";
            weaklabel.Visibility = Visibility.Hidden;
            stronglabel.Visibility = Visibility.Hidden;
            bgweak.Visibility = Visibility.Hidden;
            bgstrong.Visibility = Visibility.Hidden;
            weakness.Content = "";
            strength.Content = "";
            evidenceone.SelectedIndex = 7;
            evidencetwo.SelectedIndex = 7;
            evidencethree.SelectedIndex = 7;
        }
    }
}
