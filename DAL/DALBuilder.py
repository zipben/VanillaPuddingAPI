#!/usr/bin/env python

print "Enter the entity youd like build the hand holder for"
testFile = open("DALHandholder.cs", "a")

##read in all the lines
file = open("DALHandholder.cs", "r")
lines = file.readlines()
file.close

##write lines back except for closing parentheses

file = open("DALHandholder.cs", "w")

for idx, val in enumerate(lines):
    if idx < len(lines) - 1:
        file.write(val)

file.close()

##append new content
file = open("DALHandholder.cs", "a")


entityName = "TestEntity"
entityNameToLower = "testEntity"

#Get single entity
file.write("\tpublic "+entityName + " Get"+entityName+"(int " + entityName + "Id){\n")
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
file.write("\t\t\treturn db."+entityName+"s.OrderBy(c => c.GetType().GetProperty(orderBy)).ToList();\n")    
file.write("\t\t\t}\n")             
file.write("\t\t\n")      
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
file.write("\t\treturn client;\n")
file.write("\t\t}\n")         
file.write("\t}\n")


file.write("\n}")
testFile.close()