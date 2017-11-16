#!/usr/bin/env python

#lookup entities


entityFile = open("../DAL/DAL.Entities.cs", "r")
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

# entities.append("Testing")

print entities
entityFile.close()

for entity in entities:
    #Get all lines from controller
    try:
        controllerFile = open(entity+"Controller.cs", "r")    
        controllerLines = controllerFile.readlines()
        controllerFile.close()
    except IOError:
        controllerLines = []

    with open(entity+"Controller.cs", "w") as controllerFile:

        if not controllerLines:
            #build the using references
            controllerFile.write("using System;\n")
            controllerFile.write("using System.Collections.Generic;\n")
            controllerFile.write("using System.Diagnostics;\n")
            controllerFile.write("using System.Linq;\n")
            controllerFile.write("using System.Threading.Tasks;\n")
            controllerFile.write("using Microsoft.AspNetCore.Mvc;\n")
            controllerFile.write("using Microsoft.Extensions.Logging;\n")
            controllerFile.write("using VanillaPuddingAPI.DAL;\n")
            controllerFile.write("using VanillaPuddingAPI.Models;\n")

            controllerFile.write("namespace VanillaPuddingAPI.Controllers\n")
            controllerFile.write("{\n")
            controllerFile.write("\tpublic class "+entity+"Controller : BaseController\n")
            controllerFile.write("\t{\n")
            controllerFile.write("\t\t#region custom\n")

            controllerFile.write("\t\t#endregion\n")
        else:
            lookingForGeneratedRegion = True
            #loop over all the lines in the file until we hit the generated region
            for controllerLine in controllerLines:
                if(lookingForGeneratedRegion):
                    #found the generated region
                    if("#region generated" in controllerLine):
                        lookingForGeneratedRegion = False
                    else:
                        controllerFile.write(controllerLine)
                
        # at this point we have printed everything that isnt in the generated region
        # so we are going to start to print the generated code

        controllerFile.write("\t\t#region generated\n")

        
        controllerFile.write("\t\tILogger Logger;\n")

        controllerFile.write("\t\tpublic "+entity+"Controller(ILogger<"+entity+"Controller> logger){\n")
        controllerFile.write("\t\t\tLogger = logger;\n")
        controllerFile.write("\t\t}\n\n")

        controllerFile.write("\t\t[HttpGet(\"/"+entity.lower()+"s/{"+entity.lower()+"Id}\")]\n")
        controllerFile.write("\t\tpublic ActionResult "+entity+"(int "+entity.lower()+"Id){\n")
        controllerFile.write("\t\t\treturn Json(Handholder.Get"+entity+"("+entity.lower()+"Id));\n")
        controllerFile.write("\t\t}\n\n")

        controllerFile.write("\t\t[HttpGet(\"/"+entity.lower()+"s\")]\n")
        controllerFile.write("\t\tpublic ActionResult Index(){\n")
        controllerFile.write("\t\t\treturn Json(Handholder.Get"+entity+"s());\n")
        controllerFile.write("\t\t}\n\n")

        controllerFile.write("\t\t[HttpPost(\"/"+entity.lower()+"s/{"+entity.lower()+"Id}/delete\")]\n")
        controllerFile.write("\t\tpublic ActionResult Delete"+entity+"(int "+entity.lower()+"Id){\n\n")
                
                
        controllerFile.write("\t\t\tLogger.LogInformation(\"Delete "+entity+": \" + "+entity.lower()+"Id);\n")
                
        controllerFile.write("\t\t\tShitBucket sBucket = new ShitBucket();\n")
        controllerFile.write("\t\t\tHandholder.Delete"+entity+"(sBucket, "+entity.lower()+"Id);\n")

        controllerFile.write("\t\t\tif(!sBucket.IsValid){\n")
        controllerFile.write("\t\t\t\tLogger.LogError(sBucket.GetTopError());\n")
        controllerFile.write("\t\t\t}\n\n")
                
        controllerFile.write("\t\t\treturn Json(new{success = true});\n")
        controllerFile.write("\t\t}\n\n")

        controllerFile.write("\t\t[HttpPost(\"/"+entity.lower()+"s/AddEdit\")]\n")
        controllerFile.write("\t\tpublic ActionResult AddEdit"+entity+"([FromBody]"+entity + " " +entity.lower()+"){\n")
                
        controllerFile.write("\t\t\tif("+entity.lower()+"."+entity+"Id == 0){\n")
        controllerFile.write("\t\t\t\tLogger.LogInformation(\"Adding new "+entity.lower()+"\");\n")
        controllerFile.write("\t\t\t}\n")
        controllerFile.write("\t\t\telse{\n")   
        controllerFile.write("\t\t\t\tLogger.LogInformation(\"Updating "+entity+": \" + "+entity.lower()+"."+entity+"Id);\n")
        controllerFile.write("\t\t\t}\n\n")
                
        controllerFile.write("\t\t\tShitBucket sBucket = new ShitBucket();\n")
        controllerFile.write("\t\t\tHandholder.AddEdit"+entity+"(sBucket, "+entity.lower()+");\n")

        controllerFile.write("\t\t\tif(!sBucket.IsValid){\n")
        controllerFile.write("\t\t\t\tLogger.LogError(sBucket.GetTopError());\n")
        controllerFile.write("\t\t\t}\n")
                
        controllerFile.write("\t\t\treturn Json("+entity.lower()+");\n")
        controllerFile.write("\t\t}\n\n")
        controllerFile.write("\t\t#endregion\n")
        controllerFile.write("\t}\n\n")

        controllerFile.write("}\n")

                


        #load up controller
        #write back everything outside of generated region
        #write core functions


# ##read in all the lines
# file = open("DALHandholder.cs", "r")
# lines = file.readlines()
# file.close

# ##write lines back except for closing parentheses

# file = open("DALHandholder.cs", "w")

# # for idx, val in enumerate(lines):
# #     if idx < len(lines) - 1:
# #         file.write(val)

# #print headers, purge the rest
# referencesPrinted = False
# for line in lines:
#     if(referencesPrinted == False):
#         file.write(line)
#         if("public class DALHandholder" in line):
#             referencesPrinted = True


# file.close()

# ##append new content
# file = open("DALHandholder.cs", "a")

# for entity in entities:

#     entityName = entity
#     entityNameToLower = entity.lower()

#     file.write("#region " + entityName + " hand holders\n")

#     #Get single entity
#     file.write("\tpublic "+entityName + " Get"+entityName+"(int " + entityNameToLower + "Id){\n")
#     file.write("\t\tusing(var db = new Context()){\n")
#     file.write("\t\t\tList<"+entityName+"> "+entityNameToLower+"s = db."+entityName+"s.Where(x => x."+entityName+"Id == "+entityNameToLower+"Id).ToList();\n")
#     file.write("\t\t\tif("+entityNameToLower+"s.Count > 0){\n")
#     file.write("\t\t\t\treturn "+entityNameToLower+"s.FirstOrDefault();\n")
#     file.write("\t\t\t}\n")
#     file.write("\t\t\telse{\n")
#     file.write("\t\t\t\treturn null;\n")
#     file.write("\t\t\t}\n")             
#     file.write("\t\t}\n")        
#     file.write("\t}\n")

#     #get list of entities
#     file.write("\tpublic List<"+entityName+"> Get"+entityName+"s(string orderBy = \"\"){\n")
#     file.write("\t\tusing(var db = new Context()){\n")
#     file.write("\t\t\tif(string.IsNullOrWhiteSpace(orderBy))\n")
#     file.write("\t\t\t\treturn db."+entityName+"s.ToList();\n")
#     file.write("\t\t\telse{\n")
#     file.write("\t\t\t\treturn db."+entityName+"s.OrderBy(c => c.GetType().GetProperty(orderBy)).ToList();\n")    
#     file.write("\t\t\t}\n")             
#     file.write("\t\t}\n")      
#     file.write("\t}\n")     

#     #add edit entity
#     file.write("\tpublic "+entityName+" AddEdit"+entityName+"(ShitBucket shitBucket, "+entityName+" "+entityNameToLower+"){\n")
#     file.write("\t\tusing(var db = new Context()){\n")
#     file.write("\t\t\tif(db."+entityName+"s.Where(c => c."+entityName+"Id == "+entityNameToLower+"."+entityName+"Id).Count() == 0)\n")
#     file.write("\t\t\t\tdb."+entityName+"s.Add("+entityNameToLower+");\n")
#     file.write("\t\t\telse\n")
#     file.write("\t\t\t\tdb."+entityName+"s.Update("+entityNameToLower+");\n")
#     file.write("\t\t\ttry{\n")
#     file.write("\t\t\t\tdb.SaveChanges();\n")
#     file.write("\t\t\t}\n")
#     file.write("\t\t\tcatch(Exception e){\n")
#     file.write("\t\t\t\tshitBucket.AddError(e.Message);\n")
#     file.write("\t\t\t}\n")        
#     file.write("\t\treturn "+entityNameToLower+";\n")
#     file.write("\t\t}\n")         
#     file.write("\t}\n")

#     #delete entity
#     file.write("\tpublic void Delete"+entityName+"(ShitBucket shitBucket, int "+entityNameToLower+"Id){\n")
#     file.write("\t\tusing(var db = new Context()){\n")
#     file.write("\t\t\tdb."+entityName+"s.Remove(db."+entityName+"s.Where(c => c."+entityName+"Id == "+entityNameToLower+"Id).FirstOrDefault());\n")
#     file.write("\t\t\ttry{\n")
#     file.write("\t\t\t\tdb.SaveChanges();\n")
#     file.write("\t\t\t}\n")
#     file.write("\t\t\tcatch(Exception e){\n")
#     file.write("\t\t\t\tshitBucket.AddError(e.Message);\n")
#     file.write("\t\t\t}\n")
#     file.write("\t\t}\n")
#     file.write("\t}\n")

#     file.write("#endregion\n")


# file.write("\n}")
# file.close()