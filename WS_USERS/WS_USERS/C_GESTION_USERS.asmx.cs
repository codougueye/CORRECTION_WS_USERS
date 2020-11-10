using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Services;

namespace WS_USERS
{
	/// <summary>
	/// Description résumée de C_GESTION_USERS
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
	// [System.Web.Script.Services.ScriptService]
	public class C_GESTION_USERS : System.Web.Services.WebService
	{
		public class C_USER
		{
			public string Nom { get; set; }
			public string Prenom { get; set; }
			public int Age { get; set; }

		}
		//-------------------------------------------

		static SortedDictionary<int, C_USER> Les_Users = new SortedDictionary<int, C_USER>();

		//################################################
		[WebMethod]
		public int Ajoute_User(C_USER P_User)
		{

			int Cle = P_User.Nom.GetHashCode();
			try {
				Les_Users.Add(Cle, P_User);
			}
			catch (Exception) {
				Cle = -1;
			}
			return Cle;

		}
		//---------------------------------

		[WebMethod]
		public C_USER Donne_User(int P_Cle)
		{
			if (Les_Users.ContainsKey(P_Cle)) return Les_Users[P_Cle];
			else return new C_USER() { Nom = "user inconnu" };
		}

		//---------------------------------
		[WebMethod]
		public List<C_USER> Donne_Liste()
		{
			return Les_Users.Values.ToList();
		}

		//---------------------------------
		[WebMethod]
		public void Effacer_Liste()
		{
			Les_Users.Clear();
		}
	}
}
