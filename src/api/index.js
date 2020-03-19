export const config = {
  baseURL: '/api/',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('user-token') || ''}`,
  }
}
