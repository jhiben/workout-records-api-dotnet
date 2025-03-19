import 'package:flutter/material.dart';
import 'package:flutter_app/models/workout.dart';
import 'package:flutter_app/services/api_service.dart';

class WorkoutForm extends StatefulWidget {
  final Function(Workout) onSubmit;

  WorkoutForm({required this.onSubmit});

  @override
  _WorkoutFormState createState() => _WorkoutFormState();
}

class _WorkoutFormState extends State<WorkoutForm> {
  final _formKey = GlobalKey<FormState>();
  final _nameController = TextEditingController();
  final _descriptionController = TextEditingController();
  final _dateController = TextEditingController();
  final _movementsController = TextEditingController();

  @override
  void dispose() {
    _nameController.dispose();
    _descriptionController.dispose();
    _dateController.dispose();
    _movementsController.dispose();
    super.dispose();
  }

  void _submitForm() async {
    if (_formKey.currentState!.validate()) {
      final workout = Workout(
        id: '',
        name: _nameController.text,
        description: _descriptionController.text,
        date: DateTime.parse(_dateController.text),
        movements: [], // Add logic to parse movements
      );

      try {
        await ApiService.addWorkout(workout);
        widget.onSubmit(workout);
        _formKey.currentState!.reset();
      } catch (e) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Failed to add workout')),
        );
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        children: [
          TextFormField(
            controller: _nameController,
            decoration: InputDecoration(labelText: 'Name'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter a name';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _descriptionController,
            decoration: InputDecoration(labelText: 'Description'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter a description';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _dateController,
            decoration: InputDecoration(labelText: 'Date'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter a date';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _movementsController,
            decoration: InputDecoration(labelText: 'Movements'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter movements';
              }
              return null;
            },
          ),
          SizedBox(height: 16.0),
          ElevatedButton(
            onPressed: _submitForm,
            child: Text('Add Workout'),
          ),
        ],
      ),
    );
  }
}
