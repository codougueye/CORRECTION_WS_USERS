using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace CLIENT_CONSOLE
{

	namespace NS_WS
	{
		public partial class C_USER  // la classe générée est partielle on peut donc la compléter ici 
		{
			public override string ToString()
			{
				return $"{Nom} - {Prenom} {Age} ans";
			}
		}
	}
	//==============================================
	class Program
	{
		static NS_WS.C_GESTION_USERSSoapClient Le_serveur = new NS_WS.C_GESTION_USERSSoapClient();

		static void Main(string[] args)
		{
			try {
				Le_serveur.Effacer_Liste();

				NS_WS.C_USER Un_User = new NS_WS.C_USER() { Nom = "user1", Prenom = "Prenom1", Age = 10 };


				int Cle = Le_serveur.Ajoute_User(Un_User);
				Console.WriteLine($"le user {Un_User} a été ajouté clé : {Cle}");

				Un_User = new NS_WS.C_USER() { Nom = "user2", Prenom = "Prenom2", Age = 11 };
				Cle = Le_serveur.Ajoute_User(Un_User);
				Console.WriteLine($"le user {Un_User} a été ajouté clé : {Cle}");

				Un_User = new NS_WS.C_USER() { Nom = "user3", Prenom = "Prenom3", Age = 12 };
				Cle = Le_serveur.Ajoute_User(Un_User);
				Console.WriteLine($"le user {Un_User} a été ajouté clé : {Cle}");

				Console.WriteLine();
				var Les_Users = Le_serveur.Donne_Liste();
				Console.WriteLine("La Liste :");
				foreach (var un_element in Les_Users) {
					Console.WriteLine(un_element);
				}
				Console.WriteLine();
				Console.WriteLine("recherche du user 1");
				var Reponse = Le_serveur.Donne_User("user1".GetHashCode());
				Console.WriteLine(Reponse);

				Console.WriteLine();
				Console.WriteLine("recherche du user 3");
				Reponse = Le_serveur.Donne_User("user3".GetHashCode());
				Console.WriteLine(Reponse);
			} catch(Exception) {
				Console.WriteLine("ERREUR le serveur n'est peut être pas lancé !!");
			}
		}
	}
}
