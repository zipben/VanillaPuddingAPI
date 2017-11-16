#!/usr/bin/env python

#lookup entities


entityFile = open("DAL.Entities.cs", "r")
entityLines = entityFile.readlines()
entities = []

#public class Order

pullEntity = False
for line in entityLines:
    if(pullEntity is True):
        lineList = line.split(" ")
        classIndex = lineList.index("class")
        entities.append(lineList[classIndex + 1].rstrip())
        pullEntity = False
    elif("//[DALBuilder]" in line):
        pullEntity = True


entityFile.close()


##read in all the lines
file = open("DALHandholder.cs", "r")
lines = file.readlines()
file.close

##write lines back except for closing parentheses

file = open("DALHandholder.cs", "w")


#print headers, purge the rest
referencesPrinted = False
for line in lines:
    if(referencesPrinted == False):
        file.write(line)
        if("public class DALHandholder" in line):
            referencesPrinted = True


file.close()

##append new content
file = open("DALHandholder.cs", "a")

for entity in entities:

    entityName = entity
    entityNameToLower = entity.lower()

    file.write("#region " + entityName + " hand holders\n")

    #Get single entity
    file.write("\tpublic "+entityName + " Get"+entityName+"(int " + entityNameToLower + "Id){\n")
    file.write("\t\tusing(var db = new Context()){\n")
    file.write("\t\t\tList<"+entityName+"> "+entityNameToLower+"s = db."+entityName+"s.Where(x => x."+entityName+"Id == "+entityNameToLower+"Id).ToList();\n")
    file.write("\t\t\tif("+entityNameToLower+"s.Count > 0){\n")
    file.write("\t\t\t\treturn "+entityNameToLower+"s.FirstOrDefault();\n")
    file.write("\t\t\t}\n")
    file.write("\t\t\telse{\n")
    file.write("\t\t\t\treturn null;\n")
    file.write("\t\t\t}\n")             
    file.write("\t\t}\n")        
    file.write("\t}\n")

    #get list of entities
    file.write("\tpublic List<"+entityName+"> Get"+entityName+"s(string orderBy = \"\"){\n")
    file.write("\t\tusing(var db = new Context()){\n")
    file.write("\t\t\tif(string.IsNullOrWhiteSpace(orderBy))\n")
    file.write("\t\t\t\treturn db."+entityName+"s.ToList();\n")
    file.write("\t\t\telse{\n")
    file.write("\t\t\t\treturn db."+entityName+"s.OrderBy(c => c.GetType().GetProperty(orderBy)).ToList();\n")    
    file.write("\t\t\t}\n")             
    file.write("\t\t}\n")      
    file.write("\t}\n")     

    #add edit entity
    file.write("\tpublic "+entityName+" AddEdit"+entityName+"(ShitBucket shitBucket, "+entityName+" "+entityNameToLower+"){\n")
    file.write("\t\tusing(var db = new Context()){\n")
    file.write("\t\t\tif(db."+entityName+"s.Where(c => c."+entityName+"Id == "+entityNameToLower+"."+entityName+"Id).Count() == 0)\n")
    file.write("\t\t\t\tdb."+entityName+"s.Add("+entityNameToLower+");\n")
    file.write("\t\t\telse\n")
    file.write("\t\t\t\tdb."+entityName+"s.Update("+entityNameToLower+");\n")
    file.write("\t\t\ttry{\n")
    file.write("\t\t\t\tdb.SaveChanges();\n")
    file.write("\t\t\t}\n")
    file.write("\t\t\tcatch(Exception e){\n")
    file.write("\t\t\t\tshitBucket.AddError(e.Message);\n")
    file.write("\t\t\t}\n")        
    file.write("\t\treturn "+entityNameToLower+";\n")
    file.write("\t\t}\n")         
    file.write("\t}\n")

    #delete entity
    file.write("\tpublic void Delete"+entityName+"(ShitBucket shitBucket, int "+entityNameToLower+"Id){\n")
    file.write("\t\tusing(var db = new Context()){\n")
    file.write("\t\t\tdb."+entityName+"s.Remove(db."+entityName+"s.Where(c => c."+entityName+"Id == "+entityNameToLower+"Id).FirstOrDefault());\n")
    file.write("\t\t\ttry{\n")
    file.write("\t\t\t\tdb.SaveChanges();\n")
    file.write("\t\t\t}\n")
    file.write("\t\t\tcatch(Exception e){\n")
    file.write("\t\t\t\tshitBucket.AddError(e.Message);\n")
    file.write("\t\t\t}\n")
    file.write("\t\t}\n")
    file.write("\t}\n")

    file.write("#endregion\n")


file.write("\n}")
file.close()