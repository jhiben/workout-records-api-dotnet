const workouts = [
  {
    id: 1,
    name: 'Workout 1',
    movements: [
      { name: 'Push-Up', reps: 20 },
      { name: 'Pull-Up', reps: 10 },
    ],
    timeCap: '20:00',
    roundsCount: 3,
  },
  {
    id: 2,
    name: 'Workout 2',
    movements: [
      { name: 'Squat', reps: 30 },
      { name: 'Burpee', reps: 15 },
    ],
    timeCap: '15:00',
    roundsCount: 4,
  },
];

export default function handler(req, res) {
  res.status(200).json(workouts);
}
