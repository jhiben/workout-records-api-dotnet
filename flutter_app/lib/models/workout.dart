class Workout {
  final String id;
  final String name;
  final String description;
  final DateTime date;
  final List<WorkoutMovement> movements;

  Workout({
    required this.id,
    required this.name,
    required this.description,
    required this.date,
    required this.movements,
  });

  factory Workout.fromJson(Map<String, dynamic> json) {
    return Workout(
      id: json['id'],
      name: json['name'],
      description: json['description'],
      date: DateTime.parse(json['date']),
      movements: (json['movements'] as List)
          .map((movement) => WorkoutMovement.fromJson(movement))
          .toList(),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'name': name,
      'description': description,
      'date': date.toIso8601String(),
      'movements': movements.map((movement) => movement.toJson()).toList(),
    };
  }
}

class WorkoutMovement {
  final String name;
  final String description;
  final int reps;
  final int weight;
  final int distance;

  WorkoutMovement({
    required this.name,
    required this.description,
    required this.reps,
    required this.weight,
    required this.distance,
  });

  factory WorkoutMovement.fromJson(Map<String, dynamic> json) {
    return WorkoutMovement(
      name: json['name'],
      description: json['description'],
      reps: json['reps'],
      weight: json['weight'],
      distance: json['distance'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'name': name,
      'description': description,
      'reps': reps,
      'weight': weight,
      'distance': distance,
    };
  }
}
