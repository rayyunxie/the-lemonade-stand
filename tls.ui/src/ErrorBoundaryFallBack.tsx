import { Button, Typography } from '@mui/material';
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
