import xlwings as xw
import json
import os

titleLine = 2  # excel标题所在row-1


def isNumber(content):
    """判断是否为数字
    """
    try:
        int(content)
        return True
    except BaseException:
        return False


def tryNum(content):
    """尝试转为数字，不能转的不变
    """
    if isNumber(content):
        if float(content) == int(content):
            return int(content)
        else:
            return float(content)
    else:
        return content


def xlFileToJsonFile(app, dataFloder, xlFloder, xlFoldName, xlName):
    if xlName[-4:] == 'xlsx' and xlName[0] != '~':
        if xlFoldName is not None:
            xlFoldPath = os.path.join(xlFloder, xlFoldName)
            jsonFolder = os.path.join(dataFloder, xlFoldName)
        else:
            xlFoldPath = xlFloder
            jsonFolder = dataFloder
        print("--------Excel:" + xlName)
        xlPath = os.path.join(xlFoldPath, xlName)
        xlFile = app.books.open(xlPath, update_links=False, read_only=True)
        dataMap = {}
        for sht in xlFile.sheets:
            if sht.name[0] != '#':
                print("Sheet:" + sht.name)
                usedList = sht.used_range.value
                titleList = usedList[titleLine]  # 第3行为标题
                # shtMap = {}
                mapList = []
                for r in range(titleLine + 1, len(usedList)):  # 第4行开始正式数据
                    lineMap = {}
                    for c in range(len(titleList)):
                        if titleList[c] is not None:
                            lineMap[titleList[c]] = tryNum(usedList[r][c])
                    mapList.append(lineMap)
                dataMap[sht.name] = mapList

        if not os.path.exists(jsonFolder):
            os.makedirs(jsonFolder)
        jsonFile = open(os.path.join(jsonFolder, xlName[:-5] + '.json'), 'w', encoding='utf-8')
        jsonStr = json.dumps(mapList, indent=2, ensure_ascii=False)
        jsonFile.write(jsonStr)
        jsonFile.close()
        xlFile.close()


app = xw.App(visible=False, add_book=False)
app.display_alerts = False
try:
    xlFloder = os.path.join(os.getcwd(), '..', 'Excel')
    dataFloder = os.path.join(os.getcwd(), '..\\..', 'Assets\\Data')
    xlFolds = os.listdir(xlFloder)
    for xlFFName in xlFolds:
        xlFFPath = os.path.join(xlFloder, xlFFName)
        if os.path.isdir(xlFFPath):
            print("----------------Folder:" + xlFFName + "----------------")
            xlFiles = os.listdir(xlFFPath)
            for xlName in xlFiles:
                xlFileToJsonFile(app, dataFloder, xlFloder, xlFFName, xlName)
        elif xlFFPath[-4:] == 'xlsx' and xlFFPath[0] != '~':
            xlFileToJsonFile(app, dataFloder, xlFloder, None, xlFFName)
finally:
    app.quit()
