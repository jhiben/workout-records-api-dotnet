import 'package:flutter/material.dart';
import 'package:flutter_app/services/api_service.dart';
import 'package:flutter_app/widgets/workout_form.dart';
import 'package:flutter_app/widgets/workout_list.dart';
import 'package:flutter_app/models/workout.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  List<Workout> _workouts = [];
  bool _isLoading = false;
  String _errorMessage = '';

  @override
  void initState() {
    super.initState();
    _fetchWorkouts();
  }

  Future<void> _fetchWorkouts() async {
    setState(() {
      _isLoading = true;
      _errorMessage = '';
    });

    try {
      final workouts = await ApiService.fetchWorkouts();
      setState(() {
        _workouts = workouts;
      });
    } catch (e) {
      setState(() {
        _errorMessage = 'Failed to load workouts';
      });
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }

  void _addWorkout(Workout workout) {
    setState(() {
      _workouts.add(workout);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Workout Records'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            WorkoutForm(onSubmit: _addWorkout),
            SizedBox(height: 16.0),
            if (_isLoading)
              CircularProgressIndicator()
            else if (_errorMessage.isNotEmpty)
              Text(_errorMessage, style: TextStyle(color: Colors.red)),
            else
              Expanded(child: WorkoutList(workouts: _workouts)),
          ],
        ),
      ),
    );
  }
}
