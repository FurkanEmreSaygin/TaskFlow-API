import { useState } from 'react';
import { tasksAPI } from '../api/tasks';

export default function AddTask({ onClose, onTaskAdded }) {
  const [formData, setFormData] = useState({
    baslik: '',
    aciklama: ''
  });
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await tasksAPI.createTask(formData);
      onTaskAdded();
      onClose();
    } catch (error) {
      setError(error.message);
      console.error('API Error Details:', error);
    }
  };

  return (
    <div className="modal-overlay">
      <div className="add-task-modal">
        <h2>Yeni Görev Ekle</h2>
        {error && <div className="error-message">{error}</div>}
        
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Başlık*"
            value={formData.baslik}
            onChange={(e) => setFormData({...formData, baslik: e.target.value})}
            required
            minLength={3}
          />
          
          <textarea
            placeholder="Açıklama"
            value={formData.aciklama}
            onChange={(e) => setFormData({...formData, aciklama: e.target.value})}
            required
            minLength={10}
          />
          
          <div className="modal-actions">
            <button type="submit">Ekle</button>
            <button type="button" onClick={onClose}>İptal</button>
          </div>
        </form>
      </div>
    </div>
  );
}