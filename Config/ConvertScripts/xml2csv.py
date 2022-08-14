import csv
import xml.etree.ElementTree as ET
import os

xmlFloder = os.path.abspath(os.path.join(os.getcwd(), '.', 'XML'))
csvFloder = os.path.abspath(os.path.join(os.getcwd(), '.', 'CSV'))

xmlFiles = os.listdir(xmlFloder)
for xmlName in xmlFiles:
    if xmlName[-3:] == 'xml':
        print(xmlName)
        xmlPath = os.path.join(xmlFloder, xmlName)
        tree = ET.parse(xmlPath)
        root = tree.getroot()
        for child in root:
            csvPath = os.path.join(csvFloder, child.tag + '.csv')
            with open(csvPath, 'w', newline='', encoding='utf-8-sig') as csvFile:
                head = child[0].attrib.keys()
                csvWriter = csv.DictWriter(csvFile, head)
                csvWriter.writeheader()
                for item in child:
                    csvWriter.writerow(item.attrib)
