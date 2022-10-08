import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { FallbackProps } from 'react-error-boundary';

export const ErrorBoundaryFallBack = ({
  error,
  resetErrorBoundary,
}: FallbackProps) => {
  return (
    <div>
      <Typography component='h1' variant='h4'>
        An error has occurred
      </Typography>
      <pre>{error.message}</pre>
      <Button onClick={resetErrorBoundary}>Try Again</Button>
    </div>
  );
};
