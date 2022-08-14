import xml.etree.ElementTree as ET
import pandas as pd
import os

path = os.path

xmlFloder = path.join(os.getcwd(), '..', 'XML')
xlFloder = path.join(os.getcwd(), '..', 'Excel')

xmlFiles = os.listdir(xmlFloder)
for xmlFile in xmlFiles:
    if xmlFile[-3:] == 'xml':
        print(xmlFile)
        xmlPath = path.join(xmlFloder, xmlFile)
        tree = ET.parse(xmlPath)
        root = tree.getroot()
        xlName = xmlFile[:-4] + '.xlsx'
        xlPath = path.join(xlFloder, xlName)
        if path.exists(xlPath):  # excel存在时，只修改数据
            writer = pd.ExcelWriter(
                xlPath,
                engine="openpyxl",
                mode='a',
                if_sheet_exists='overlay',
            )
        else:
            writer = pd.ExcelWriter(xlPath, mode='w')
        for child in root:
            if len(child) > 0:  # 有多层结构，如MOD.xml
                # 第二层结构名作为表名
                shtName = str.lower(child.tag[0]) + child.tag[1:] + 's'
                df = pd.DataFrame()
                for item in child:
                    df2 = pd.DataFrame([item.attrib])
                    df2.rename(columns=lambda x: str.lower(x[0]) + x[1:], inplace=True)
                    if len(df) == 0:
                        df = df2
                    else:
                        df = pd.concat([df, df2])
                df.to_excel(writer, shtName, index=False, startrow=2)
            else:  # 只有一层结构 如Magic.xml
                shtName = str.lower(child.tag) + 's'
                df = pd.read_xml(xmlPath)
                df.rename(columns=lambda x: str.lower(x), inplace=True)
                df.to_excel(writer, shtName, index=False, startrow=2)
                break
        writer.close()
