import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:nedersin/SurveyPage.dart';

class MainPage extends StatefulWidget {
  const MainPage({super.key});

  @override
  State<MainPage> createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {
  Column column = Column();
  @override
  void initState() {
    super.initState();
    fetchdata(context).then((value) => setState(
          () => column = Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: value,
          ),
        ));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: column,
    );
  }

  Future<List<Widget>> fetchdata(BuildContext context) async {
    final dio = Dio();
    Response response;
    response = await dio.getUri(Uri.parse("https://localhost:7226/Page/"),
        data: VM_PageValue(100, 20, "StartDate", "ASC"),
        options: Options(headers: <String, dynamic>{
          "Content-Type": "application/json"
        }));

    response.data["data"];
    List<SurveyList> surveyList = [];
    for (Map<String, dynamic> element in response.data["data"]["data"]["surveyList"]) {
      surveyList.add(SurveyList.fromJson(element));
    }
    SurveyData surveyData = SurveyData(response.data["data"]["data"]["order"], response.data["data"]["data"]["short"], response.data["data"]["data"]["maxPage"], response.data["data"]["data"]["pageSize"], surveyList);
    ReturnData returnData = ReturnData(response.data["data"]["status"], response.data["data"]["message"] ?? "", surveyData, response.data["data"]["exception"] ?? "");
    SurveyMainList surveyMainList = SurveyMainList(response.data["apiMessage"], returnData, response.data["hateoas"]);

    List<Widget> cards = [
      Text("test1")
    ];

    cards.add(
      Text("apimessage = " + surveyMainList.apiMessage.toString() + " hateoas = " + surveyMainList.hashCode.toString()),
    );

    cards.add(
      Text("status = " + (surveyMainList.data?.status ?? false).toString() + " message = " + (surveyMainList.data?.message).toString() + " exception = " + (surveyMainList.data?.exception).toString()),
    );

    cards.add(
      Text("order = " + (surveyMainList.data?.data?.order ?? "").toString() + " short = " + (surveyMainList.data?.data?.short ?? "").toString() + " maxpage = " + (surveyMainList.data?.data?.maxPage ?? "").toString() + " pageSize = " + (surveyMainList.data?.data?.pageSize ?? "").toString()),
    );

    for (SurveyList element in surveyMainList.data?.data?.surveyList ?? []) {
      cards.add(Row(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Expanded(
            child: Card(
            color: Colors.grey,
            child: GestureDetector(
              child: Text(element.title.toString() + "      " + element.rating.toString() + "         " + element.userName.toString()),
              onTap: () => Navigator.push(context, MaterialPageRoute(builder: (context) => SurveyPage(surveyAddress: element.address.toString()))),
            ),
          )),
        ],
      ));
    }
    print(cards);
    return cards;
  }
}

class VM_PageValue {
  int pageNumber;
  int pageSize;
  String order;
  String shortType;

  VM_PageValue(this.pageNumber, this.pageSize, this.order, this.shortType);

  Map<String, dynamic> toJson() {
    return {
      'pageNumber': pageNumber,
      'pageSize': pageSize,
      'order': order,
      'shortType': shortType,
    };
  }
}

class SurveyMainList {
  String? apiMessage = null;
  ReturnData? data = null;
  Object? hateoas = null;

  SurveyMainList._initialize();
  factory SurveyMainList.uret() => SurveyMainList._initialize();

  factory SurveyMainList(String? apiMessage, ReturnData? data, Object? hateoas) {
    SurveyMainList constructor = SurveyMainList._initialize();
    constructor.apiMessage = apiMessage;
    constructor.data = data;
    constructor.hateoas = hateoas;
    return constructor;
  }

  factory SurveyMainList.fromJson(Map<String, dynamic> json) {
    return SurveyMainList(json["apiMessage"], ReturnData.fromJson(json["data"]), json[" hateoas"]);
  }
}

class ReturnData {
  bool? status;
  String? message;
  SurveyData? data;
  String? exception;

  ReturnData._initialize();
  factory ReturnData.uret() => ReturnData._initialize();

  factory ReturnData(bool status, String message, SurveyData data, String exception) {
    ReturnData constructor = ReturnData._initialize();
    constructor.status = status;
    constructor.message = message;
    constructor.data = data;
    constructor.exception = exception;
    return constructor;
  }

  factory ReturnData.fromJson(Map<String, dynamic> json) {
    return ReturnData(json[" status"], json[" message"], SurveyData.fromJson(json[" data"]), json["exception"]);
  }
}

class SurveyData {
  String? order;
  String? short;
  int? maxPage;
  int? pageSize;
  List<SurveyList>? surveyList;
  SurveyData._initialize();
  factory SurveyData.uret() => SurveyData._initialize();

  factory SurveyData(String order, String short, int maxPage, int pageSize, List<SurveyList> surveyList) {
    SurveyData constructor = SurveyData._initialize();
    constructor.order = order;
    constructor.short = short;
    constructor.maxPage = maxPage;
    constructor.pageSize = pageSize;
    constructor.surveyList = surveyList;
    return constructor;
  }

  factory SurveyData.fromJson(Map<String, dynamic> json) {
    return SurveyData(json[" order"], json[" short"], json[" maxPage"], json[" pageSize"], (json[" surveyList"] as List<dynamic>).map((e) => SurveyList.fromJson(e)).toList());
  }
}

class SurveyList {
  String? address;
  int? userId;
  String? userName;
  String? title;
  double? rating;

  SurveyList._initialize();
  factory SurveyList.uret() => SurveyList._initialize();

  factory SurveyList(String address, int userId, String userName, String title, double rating) {
    SurveyList constructor = SurveyList._initialize();
    constructor.address = address;
    constructor.userId = userId;
    constructor.userName = userName;
    constructor.title = title;
    constructor.rating = rating;
    return constructor;
  }

  factory SurveyList.fromJson(Map<String, dynamic> json) {
    return SurveyList(json["address"], json["userId"], json["userName"], json["title"], json["rating"]);
  }
}
