using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfGestionStock.Model;

namespace WcfGestionStock
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private BdStockLp2023Entities db = new BdStockLp2023Entities();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool AjouterProduit(Produit p)
        {
            try
            {
                db.Produit.Add(p);
                db.SaveChanges();
                return true;
            }catch (Exception ex)
            {

            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Produit> getProduitList()
        {
            return db.Produit.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produit getProduit(int? id)
        { 
            return db.Produit.Find(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ModifierProduit(Produit p)
        {
            try
            {
                db.Entry(p);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SupprimerProduit(int? id)
        {
            try
            {
                var p = db.Produit.Find(id);
                db.Produit.Remove(p);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
