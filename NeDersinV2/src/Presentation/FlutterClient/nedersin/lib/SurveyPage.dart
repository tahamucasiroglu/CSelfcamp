import 'package:dio/dio.dart';
import 'package:flutter/material.dart';

class SurveyPage extends StatefulWidget {
  final String surveyAddress;
  const SurveyPage({super.key, required this.surveyAddress});

  @override
  State<SurveyPage> createState() => _SurveyPageState();
}

class _SurveyPageState extends State<SurveyPage> {
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
    return const Placeholder();
  }

  Future<List<Widget>> fetchdata(BuildContext context) async {
    final dio = Dio();
    Response response;
    response = await dio.getUri(Uri.parse("https://localhost:7226/"),
        data: SurveyPageValue(widget.surveyAddress),
        options: Options(headers: <String, dynamic>{
          "Content-Type": "application/json"
        }));

    response.data["data"];
    Survey survey = Survey.fromJson(response.data["data"]["data"]);
    SurveyData surveyData = SurveyData(response.data["data"]["status"], response.data["data"]["message"], survey, response.data["data"]["exception"]);
    SurveyReturn surveyReturn = SurveyReturn(response.data["apiMessage"], surveyData, response.data["hateoas"]);

    Response responseQuestion;
    responseQuestion = await dio.getUri(Uri.parse("https://localhost:7226/question/getbysurveyid/"),
        data: SurveuId(surveyReturn.data.data.Id),
        options: Options(headers: <String, dynamic>{
          "Content-Type": "application/json"
        }));

    


    List<Widget> cards = [];







    print(cards);
    return cards;
  }
}

class SurveyPageValue {
  String Address;
  SurveyPageValue(this.Address);
}

class SurveuId {
  int id;
  SurveuId(this.id);
}

class SurveyReturn {
  late String? apiMessage;
  late SurveyData data;
  late Object? hateoas;

  SurveyReturn._initialize();
  factory SurveyReturn.uret() => SurveyReturn._initialize();

  factory SurveyReturn(String? apiMessage, SurveyData data, Object? hateoas) {
    SurveyReturn constructor = SurveyReturn._initialize();
    constructor.apiMessage = apiMessage;
    constructor.data = data;
    constructor.hateoas = hateoas;
    return constructor;
  }

  factory SurveyReturn.fromJson(Map<String, dynamic> json) {
    return SurveyReturn(json["apiMessage"], SurveyData.fromJson(json["data"]), json[" hateoas"]);
  }
}

class SurveyData {
  late bool status;
  late String? message;
  late Survey data;
  late String? exeption;
  SurveyData._initialize();
  factory SurveyData.uret() => SurveyData._initialize();

  factory SurveyData(bool status, String? message, Survey data, String? exeption) {
    SurveyData constructor = SurveyData._initialize();
    constructor.status = status;
    constructor.message = message;
    constructor.data = data;
    constructor.exeption = exeption;
    return constructor;
  }

  factory SurveyData.fromJson(Map<String, dynamic> json) {
    return SurveyData(
      json[" status"],
      json[" message"],
      json[" data"],
      json[" exception"],
    );
  }
}

class Survey {
  late int Id;
  late String Address;
  late int UserId;
  late String Title;
  late String Describtion;
  late DateTime Date;
  late bool IsEnd;
  late DateTime? EndTime;
  late int? MaxResponse;
  late int? MinResponse;
  late int ResponseCount;
  late int ViewCount;
  late double Rating;

  Survey._initialize();
  factory Survey.uret() => Survey._initialize();

  factory Survey(int id, String address, int userid, String title, String descibtion, DateTime date, bool isend, DateTime? endDate, int? maxresponse, int? minresponse, int responsecount, int viewcount, double rating) {
    Survey constructor = Survey._initialize();
    constructor.Id = id;
    constructor.Address = address;
    constructor.UserId = userid;
    constructor.Title = title;
    constructor.Describtion = descibtion;
    constructor.Date = date;
    constructor.IsEnd = isend;
    constructor.EndTime = endDate;
    constructor.MaxResponse = maxresponse;
    constructor.MinResponse = minresponse;
    constructor.ResponseCount = responsecount;
    constructor.ViewCount = viewcount;
    constructor.Rating = rating;
    return constructor;
  }

  factory Survey.fromJson(Map<String, dynamic> json) {
    return Survey(
      json[" id"],
      json[" adress"],
      json[" userId"],
      json[" title"],
      json[" describtion"],
      json[" date"],
      json[" isEnd"],
      json[" endTime"],
      json[" maxResponse"],
      json[" minResponse"],
      json[" responseCount"],
      json[" viewCount"],
      json[" rating"],
    );
  }
}
