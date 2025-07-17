import { tasksAPI } from '../api/tasks';

export default function TaskCard({ task, onUpdate }) {
  const toggleComplete = async () => {
    try {
      await tasksAPI.updateTask(task.id, {
        ...task,
        tamamlandiMi: !task.tamamlandiMi
      });
      onUpdate();
    } catch (error) {
      console.error('Hata:', error.message);
    }
  };

  const deleteTask = async () => {
    if (window.confirm('Bu görevi silmek istediğinize emin misiniz?')) {
      try {
        await tasksAPI.deleteTask(task.id);
        onUpdate();
      } catch (error) {
        console.error('Hata:', error.message);
      }
    }
  };

  return (
    <div className={`task-card ${task.tamamlandiMi ? 'completed' : ''}`}>
      <h3>{task.baslik}</h3>
      <p>{task.aciklama}</p>
      <p>Tarih: {new Date(task.tarih).toLocaleDateString()}</p>
      <div className="task-actions">
        <button onClick={toggleComplete}>
          {task.tamamlandiMi ? '✅ Tamamlandı' : '❌ Tamamlanmadı'}
        </button>
        <button onClick={deleteTask} className="delete-btn">Sil</button>
      </div>
    </div>
  );
}