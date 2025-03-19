import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter_app/models/workout.dart';

class ApiService {
  static const String _baseUrl = 'https://api.example.com';

  static Future<List<Workout>> fetchWorkouts() async {
    final response = await http.get(Uri.parse('$_baseUrl/workouts'));

    if (response.statusCode == 200) {
      final List<dynamic> data = json.decode(response.body);
      return data.map((json) => Workout.fromJson(json)).toList();
    } else {
      throw Exception('Failed to load workouts');
    }
  }

  static Future<void> addWorkout(Workout workout) async {
    final response = await http.post(
      Uri.parse('$_baseUrl/workouts'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(workout.toJson()),
    );

    if (response.statusCode != 201) {
      throw Exception('Failed to add workout');
    }
  }
}
