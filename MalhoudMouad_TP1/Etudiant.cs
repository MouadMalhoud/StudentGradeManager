using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalhoudMouad_TP1
{
    class Etudiant
    {
        public string[] matieresDossier = { "Philosophie", "Algorithmie et programmation", "Outils et profession", "Français", "Anglais" };
        //Attributs
        private string _prenom;
        private string _nom;
        private string _codePermanent;
        private string[] _matiere= new string[5];
        private int[] _notes = new int[5];
        // Constructeur par défaut
        public Etudiant()
        {
            _prenom = null;
            _nom = null;
            _codePermanent = null;
            _matiere = null;
            _notes = null;
        }
        // Constructeurs à paramètres 
        public Etudiant(string pPrenom, string pNom, string pCodePermanent, string[] pMatiere, int[] pNotes)
        {
            _prenom = pPrenom;
            _nom = pNom;
            _codePermanent = pCodePermanent;
            _matiere = matieresDossier;
            _notes = pNotes;
        }

        // Getter & Setter
        public string prenom
        {
            get { return this._prenom;  }
            set { this._prenom = value; }
        }
        public string nom
        {
            get { return this._nom; }
            set { this._nom = value; }
        }
        public string codePermanent
        {
            get { return this._codePermanent; }
            set { this._codePermanent = value; }
        }
             public string[] matiere
        {
            get { return this._matiere; }
            set { this._matiere = value; }
        }
        public int[] notes
        {
            get { return this._notes; }
            set { this._notes = value; }
        }
        public override string ToString()
        {
            return prenom + " " + nom + "\r\n";
        }
    }
    }

