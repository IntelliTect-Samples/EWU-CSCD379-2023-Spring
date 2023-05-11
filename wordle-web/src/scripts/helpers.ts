export function formatTime(seconds: number): string {
  const remainingSeconds = Math.floor(seconds % 60)
  const minutes = Math.floor(seconds / 60)
  const formattedMinutes = String(minutes).padStart(2, '0')
  const formattedSeconds = String(remainingSeconds).padStart(2, '0')
  return `${formattedMinutes}:${formattedSeconds}`
}
