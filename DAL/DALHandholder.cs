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
           return db.Clients.OrderBy(c => c.ClientId).ToList();
        }
    }

    public Client AddEditClient(ShitBucket shitBucket, Client client){
        using(var db = new Context()){
            
            //Client targetClient = db.Clients.Contains(c => c.ClientId == client.ClientId);
            if(db.Clients.Where(c => c.ClientId == client.ClientId).Count() == 0)
                db.Clients.Add(client);
            else
                db.Clients.Update(client);
            try{
                db.SaveChanges();
            }
            catch(Exception e){
                shitBucket.AddError(e.Message);
            }

            return client;
        }
    }

    public void DeleteClient(ShitBucket shitBucket, int clientId){
        using(var db = new Context()){
            db.Clients.Remove(db.Clients.Where(c => c.ClientId == clientId).FirstOrDefault());
            try{
                db.SaveChanges();
            }
            catch(Exception e){
                shitBucket.AddError(e.Message);
            }
        }
    }
}