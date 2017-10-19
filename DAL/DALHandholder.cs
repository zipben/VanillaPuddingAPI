using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using VanillaPuddingAPI.DAL;

public class DALHandholder{
    public Client GetClient(int clientId){
        using(var db = new Context()){
            List<Client> clients = db.Clients.Where(c => c.ClientId == clientId).ToList();

            if(clients.Count > 0){
                return clients.FirstOrDefault();
            }
            else{
                return null;
            }
        }
    }
    public List<Client> GetClients(){
        using(var db = new Context()){
           return db.Clients.ToList();
        }
    }

    public Client AddEditClient(ShitBucket shitBucket, Client client){
        using(var db = new Context()){
            
            db.Clients.Add(client);

            try{
                db.SaveChanges();
            }
            catch(Exception e){
                shitBucket.AddError(e.Message);
            }

            return client;
        }
    }
}