import 'package:flutter/material.dart';
import 'package:flutter_app/models/workout.dart';

class WorkoutList extends StatelessWidget {
  final List<Workout> workouts;

  WorkoutList({required this.workouts});

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: workouts.length,
      itemBuilder: (context, index) {
        final workout = workouts[index];
        return Card(
          child: ListTile(
            title: Text(workout.name),
            subtitle: Text(workout.description),
            trailing: Text(workout.date.toIso8601String()),
          ),
        );
      },
    );
  }
}
