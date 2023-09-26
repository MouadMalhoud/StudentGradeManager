using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MalhoudMouad_TP1
{
    public partial class FrmTP1 : Form
    {
        public const int NB_MAX_ETUDIANT = 10;
        public string[] matieresDossier = { "Philosophie", "Algorithmie et programmation", "Outils et profession", "Français", "Anglais" };
        Etudiant[] tabEtudiantGroupe51 = new Etudiant[NB_MAX_ETUDIANT];
        int nbEtudiant51 = 0;
        Etudiant[] tabEtudiantGroupe52 = new Etudiant[NB_MAX_ETUDIANT];
        int nbEtudiant52 = 0;
        public FrmTP1()
        {
            InitializeComponent();
            comboBoxGroupeCahier.SelectedIndex = 0;
            comboBoxGroupeCahier.SelectedIndexChanged += new EventHandler(comboBoxGroupeCahier_SelectedIndexChanged);
            comboBoxGroupe.SelectedIndex = 0;
        }

        // Fonction qui permet de vérifier que le code permanent est valide
        public Boolean validerCodePermanent(string nom, string prenom, string codePermanent)
        {
            // Si vide
            if(codePermanent == "")
            {
                return false;
            }
            // Récupere les 2 premieres lettre du nom et prenom
            if(!validerLettreSeulement(nom) && !validerLettreSeulement(prenom)) {
                return false;
            }
            try
            {
                string nomSubbed = nom.Substring(0, 2);
                string prenomSubbed = prenom.Substring(0, 2);
                // Verifie si les 6 derniers charactère sont des chiffres
                string chiffrePerm = codePermanent.Substring(4, 6);
                for (int i = 0; i < chiffrePerm.Length; i++)
            {
                if (!Char.IsDigit(chiffrePerm[i]))
                {
                        return false;
                }
            }
            if (codePermanent.Length != 10)
            {
                    return false;
            }
                string codePerm = nomSubbed + prenomSubbed + chiffrePerm;
                if (!codePerm.Equals(codePermanent))
            {
                    return false;
            }
            }
            catch(Exception ex)
            {
            }
            
            return true;
        }
        // Fonction qui permet de vérifier que la chaine recu en paramètre contient que des lettres 
        public Boolean validerLettreSeulement(string chaine)
        {
            // Vide
            if(chaine == "")
            {
                return false;
            }
            // Besoin de minimum 2 caractère pour le code permanent
            if(chaine.Length < 2)
            {
                return false;
            }
            for(int i = 0; i < chaine.Length; i++)
            {
                // Contient autre qu'une lettre
                if (!Char.IsLetter(chaine[i]))
                {
                    return false;
                }
            }
            return true;
        }
          
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            // Fermeture (bouton quitter)
            var reponse = MessageBox.Show("Êtes vous sur de vouloir quitter ? ", "Confirmation de fermeture", MessageBoxButtons.YesNo);
            if (reponse == DialogResult.Yes)
            {
                this.Close();
            }
            else { } // Autre, ne rien faire (fermer la message box)
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            listBoxEleve.Items.Clear();
            comboBoxGroupe.Refresh();
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string codePermanent = txtCodePerm.Text;
            int notePhilo = (int)numericUpDownPhilo.Value;
            int noteAlgo = (int)numericUpDownAlgo.Value;
            int noteOutils = (int)numericUpDownOutils.Value;
            int noteFrancais = (int)numericUpDownFrancais.Value;
            int noteAnglais = (int)numericUpDownAnglais.Value;
            int[] notes = { notePhilo, noteAlgo, noteOutils, noteFrancais, noteAnglais };
 

            if (!validerLettreSeulement(nom))
            {
                errorProviderNom.SetError(txtNom, "Doit contenir que des lettres (2 minimum");
            }
            if (!validerLettreSeulement(prenom))
            {
                errorProviderPrenom.SetError(txtPrenom, "Doit contenir que des lettres (2 minimum)");
            }
            if (!validerCodePermanent(nom, prenom, codePermanent))
            {
                errorProviderCodePerm.SetError(txtCodePerm, "Code permanent incorrect");
            }

            if (validerLettreSeulement(prenom) && validerLettreSeulement(nom) && validerCodePermanent(nom, prenom, codePermanent))
          {
                if (comboBoxGroupe.Text == "Groupe 51" && nbEtudiant51 == 10)
                {
                    MessageBox.Show("Nombre d'étudiant maximal pour le groupe 51 à été atteint [10]", "Impossible d'ajouter cet étudiant ! ");
                }
                    if (comboBoxGroupe.Text == "Groupe 52" && nbEtudiant52 == 10)
                    {
                        MessageBox.Show("Nombre d'étudiant maximal pour le groupe 52 à été atteint [10]", "Impossible d'ajouter cet étudiant ! ");
                    }
                // création etudiant si groupe 51

                if (comboBoxGroupe.SelectedIndex == 0 && nbEtudiant51 < NB_MAX_ETUDIANT)
                {
                    errorProviderCodePerm.Clear();
                    errorProviderNom.Clear();
                    errorProviderPrenom.Clear();
                    tabEtudiantGroupe51[nbEtudiant51] = new Etudiant(prenom, nom, codePermanent, matieresDossier, notes);
                    nbEtudiant51++;
                }
                else
                {
                    // création etudiant si groupe 52
                    if (comboBoxGroupe.SelectedIndex == 1 && nbEtudiant52 < NB_MAX_ETUDIANT)
                    {
                        errorProviderCodePerm.Clear();
                        errorProviderNom.Clear();
                        errorProviderPrenom.Clear();
                        tabEtudiantGroupe52[nbEtudiant52] = new Etudiant(prenom, nom, codePermanent, matieresDossier, notes);
                        nbEtudiant52++;
                    }
                }
            }
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            // Efface les champs nom, code, groupe et notes
            txtNom.Text = "";
            txtPrenom.Text = "";
            comboBoxGroupe.Text = "";
            txtCodePerm.Text = "";
            numericUpDownPhilo.ResetText();
            numericUpDownAlgo.ResetText();
            numericUpDownOutils.ResetText();
            numericUpDownFrancais.ResetText();
            numericUpDownAnglais.ResetText();
        }

        private void listBoxEleve_SelectedIndexChanged(object sender, EventArgs e)
        {

                // Calcul de la moyenne
                // Remplir la listbox des etudiants a partir du tableau
                // Sortir les notes du tableau de l'étudiant parmis tous les etudiants enregistré
                int[] tabNoteTransfert = new int[5];
                int index = listBoxEleve.SelectedIndex;
                int noteTransfert = 0;
                if (comboBoxGroupeCahier.SelectedIndex == 0)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        noteTransfert = tabEtudiantGroupe51[index].notes[j];
                        tabNoteTransfert[j] = noteTransfert;

                    }
                }
                else
                {
                    if (comboBoxGroupeCahier.SelectedIndex == 1)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                        noteTransfert = tabEtudiantGroupe52[index].notes[j];
                        tabNoteTransfert[j] = noteTransfert;
                        }
                    }
                }
                
                // Remplissage des cases
                txtCoursNotePhilo.Text = tabNoteTransfert[0].ToString();
                txtCoursNoteAlgo.Text = tabNoteTransfert[1].ToString();
                txtCoursNoteOutils.Text = tabNoteTransfert[2].ToString();
                txtCoursNoteFrancais.Text = tabNoteTransfert[3].ToString();
                txtCoursNoteAnglais.Text = tabNoteTransfert[4].ToString();
                // Calcul de la moyenne
                double moyenneGen = tabNoteTransfert[0] + tabNoteTransfert[1] + tabNoteTransfert[2] + tabNoteTransfert[3] + tabNoteTransfert[4];
                moyenneGen /= 5;
                moyenneGen = Math.Round(moyenneGen, 2);
                if(moyenneGen < 60)
                {
                txtMoyenneGenerale.BackColor = Color.Black;
                txtMoyenneGenerale.ForeColor = Color.Red;
                txtMoyenneGenerale.BackColor = Color.LightSteelBlue;
                txtMoyenneGenerale.Text = moyenneGen.ToString() + " %";
            }
                else
                {
                txtMoyenneGenerale.BackColor = Color.Black;
                 txtMoyenneGenerale.ForeColor = Color.Green;
                txtMoyenneGenerale.BackColor = Color.LightSteelBlue;

                txtMoyenneGenerale.Text = moyenneGen.ToString() + " %";
                }
        }

        private void comboBoxGroupeCahier_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*   listBoxEleve.Refresh();
               listBoxEleve.BeginUpdate();
               listBoxEleve.Items.Clear();
               listBoxEleve.EndUpdate();*/
            listBoxEleve.Items.Clear();
            if (comboBoxGroupeCahier.SelectedIndex == 0)
            {
                //  Remplissage 51
                     for (int i = 0; i < nbEtudiant51; i++)
                     {
                         listBoxEleve.Items.Add(tabEtudiantGroupe51[i].ToString());
                     }
                    try {
                        // Calcul moyenne groupe pour philo
                        double notePhilo = 0;
                        for (int i = 0; i < nbEtudiant51; i++)
                        {
                            notePhilo += tabEtudiantGroupe51[i].notes[0];
                        }
                        notePhilo /= nbEtudiant51;
                        notePhilo = Math.Round(notePhilo, 2);
                        txtCoursPhiloMoyenne.Text = notePhilo.ToString() + " %";
                        // Moyenne Algo
                        double noteAlgo = 0;
                        for (int i = 0; i < nbEtudiant51; i++)
                        {
                            noteAlgo += tabEtudiantGroupe51[i].notes[1];
                        }
                        noteAlgo /= nbEtudiant51;
                        noteAlgo = Math.Round(noteAlgo, 2);
                        txtCoursAlgoMoyenne.Text = noteAlgo.ToString() + " %";
                        // Moyenne Outils
                        double noteOutil = 0;
                        for (int i = 0; i < nbEtudiant51; i++)
                        {
                            noteOutil += tabEtudiantGroupe51[i].notes[2];
                        }
                        noteOutil /= nbEtudiant51;
                         noteOutil = Math.Round(noteOutil, 2);
                        txtCoursMoyenneOutils.Text = noteOutil.ToString() + " %";
                        // moyenne francais
                        double noteFrancais = 0;
                        for (int i = 0; i < nbEtudiant51; i++)
                        {
                            noteFrancais += tabEtudiantGroupe51[i].notes[3];
                        }
                        noteFrancais /= nbEtudiant51;
                        noteFrancais = Math.Round(noteFrancais, 2);
                        txtCoursMoyenneFrancais.Text = noteFrancais.ToString() + " %";
                        // moyenne anglais
                        double noteAnglais = 0;
                        for (int i = 0; i < nbEtudiant51; i++)
                        {
                            noteAnglais += tabEtudiantGroupe51[i].notes[4];
                        }
                        noteAnglais /= nbEtudiant51;
                    noteAnglais = Math.Round(noteAnglais, 2);
                        txtCoursMoyenneAnglais.Text = noteAnglais.ToString() + " %";
                        }
                    catch (Exception ex) { }
            }
            //
            //
            //
            //
            if (comboBoxGroupeCahier.SelectedIndex == 1)
            {
                // Remplissage groupe 52
                for (int i = 0; i < nbEtudiant52; i++)
                {
                    listBoxEleve.Items.Add(tabEtudiantGroupe52[i].ToString());
                }
                try {
                    double notePhilo = 0;
                    for (int i = 0; i < nbEtudiant52; i++)
                    {
                        notePhilo += tabEtudiantGroupe52[i].notes[0];
                    }
                    notePhilo /= nbEtudiant52;
                    notePhilo = Math.Round(notePhilo, 2);
                    txtCoursPhiloMoyenne.Text = notePhilo.ToString() + " %";
                    // Moyenne Algo
                    double noteAlgo = 0;
                    for (int i = 0; i < nbEtudiant52; i++)
                    {
                        noteAlgo += tabEtudiantGroupe52[i].notes[1];
                    }
                    noteAlgo /= nbEtudiant52;
                    noteAlgo = Math.Round(noteAlgo, 2);
                    txtCoursAlgoMoyenne.Text = noteAlgo.ToString() + " %";
                    // Moyenne Outils
                    double noteOutil = 0;
                    for (int i = 0; i < nbEtudiant52; i++)
                    {
                        noteOutil += tabEtudiantGroupe52[i].notes[2];
                    }
                    noteOutil /= nbEtudiant52;
                    noteOutil = Math.Round(noteOutil, 2);
                    txtCoursMoyenneOutils.Text = noteOutil.ToString() + " %";
                    // Moyenne outils
                    double noteFrancais = 0;
                    for (int i = 0; i < nbEtudiant52; i++)
                    {
                        noteFrancais += tabEtudiantGroupe52[i].notes[3];
                    }
                    noteFrancais /= nbEtudiant52;
                    noteFrancais = Math.Round(noteFrancais, 2);
                    txtCoursMoyenneFrancais.Text = noteFrancais.ToString() + " %";
                    // Moyenne anglais
                    double noteAnglais = 0;
                    for (int i = 0; i < nbEtudiant52; i++)
                    {
                        noteAnglais += tabEtudiantGroupe52[i].notes[4];
                    }
                    noteAnglais /= nbEtudiant52;
                    noteAnglais = Math.Round(noteAnglais, 2);
                    txtCoursMoyenneAnglais.Text = noteAnglais.ToString() + " %";
                }
                catch (Exception ex) { }
            }
        }

        private void btnSupprimerEtudiant_Click(object sender, EventArgs e)
        {
            int index = listBoxEleve.SelectedIndex;
            var rep = MessageBox.Show("Voulez vous supprimer l'étudiant " + listBoxEleve.Items[index].ToString() + " de la liste ?", "Suppression d'étudiant", MessageBoxButtons.YesNo);
            if (rep == DialogResult.Yes)
            {
                try
                {
                    listBoxEleve.Items.RemoveAt(index);
                    txtCoursNotePhilo.ResetText();
                    txtCoursNoteAlgo.ResetText();
                    txtCoursNoteOutils.ResetText();
                    txtCoursNoteFrancais.ResetText();
                    txtCoursNoteAnglais.ResetText();
                }catch(Exception ex)
                {
                    MessageBox.Show("Veuillez selectionner un element", "Probleme de suppression");
                }
            }
            else { }
        }
    }
    }

    
